using AutoMapper;
using System.Collections;
using System.Collections.Concurrent;
using OnionArchitectureWebAPI.Application.Interfaces.AutoMapper;
using System.Reflection;

namespace OnionArchitectureWebAPI.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        private static readonly ConcurrentDictionary<string, global::AutoMapper.IMapper> _mapperCache = new();

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            var mapper = GetMapper(typeof(TSource), typeof(TDestination), ignore);
            return mapper.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sourceList, string? ignore = null)
        {
            var mapper = GetMapper(typeof(TSource), typeof(TDestination), ignore);
            return mapper.Map<IList<TSource>, IList<TDestination>>(sourceList);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            var mapper = GetMapper(source.GetType(), typeof(TDestination), ignore);
            return mapper.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> sourceList, string? ignore = null)
        {
            if (sourceList == null || sourceList.Count == 0) return new List<TDestination>();
            var firstItemType = sourceList[0].GetType();
            var mapper = GetMapper(firstItemType, typeof(TDestination), ignore);
            return mapper.Map<IList<TDestination>>(sourceList);
        }

        private global::AutoMapper.IMapper GetMapper(Type sourceType, Type destinationType, string? ignore)
        {
            string cacheKey = $"{sourceType.Name}_{destinationType.Name}_{ignore ?? string.Empty}";

            if (_mapperCache.TryGetValue(cacheKey, out var cachedMapper))
            {
                return cachedMapper;
            }

            var config = new MapperConfiguration(cfg =>
            {
                // Extension metodları tarama (Hata önleyici)
                cfg.ShouldMapMethod = (m => false);

                // Ana Mappleme
                var map = cfg.CreateMap(sourceType, destinationType)
                             .MaxDepth(5) // Döngüsel referans koruması
                             .ReverseMap();

                if (!string.IsNullOrEmpty(ignore))
                    map.ForMember(ignore, opt => opt.Ignore());

                // --- AKILLI TARAMA BAŞLANGICI ---
                // İçerideki sınıfları (Brand -> BrandDto gibi) otomatik bul ve ekle
                AddSubMaps(cfg, sourceType, destinationType);
            });

            var newMapper = config.CreateMapper();
            _mapperCache.TryAdd(cacheKey, newMapper);

            return newMapper;
        }

        // Alt nesneleri (Property'leri) tarayıp onlar için de CreateMap oluşturan metot
        private void AddSubMaps(IMapperConfigurationExpression cfg, Type sourceType, Type destinationType, int depth = 0)
        {
            if (depth > 3) return; // Sonsuz döngüye girmemesi için limit

            var sourceProps = sourceType.GetProperties();
            var destProps = destinationType.GetProperties();

            foreach (var destProp in destProps)
            {
                var sourceProp = sourceProps.FirstOrDefault(x => x.Name == destProp.Name);
                if (sourceProp == null) continue;

                var sType = sourceProp.PropertyType;
                var dType = destProp.PropertyType;

                // Eğer property bir Liste ise (IList<BrandDto>) içindeki tipi bul
                if (typeof(IEnumerable).IsAssignableFrom(sType) && sType != typeof(string))
                {
                    if (sType.IsGenericType && dType.IsGenericType)
                    {
                        sType = sType.GetGenericArguments()[0];
                        dType = dType.GetGenericArguments()[0];
                    }
                }

                // Eğer Property'ler Class ise ve System tipi değilse (string, int vs değilse)
                // Bu Brand ve BrandDto demektir.
                if (sType.IsClass && dType.IsClass &&
                    sType != typeof(string) && dType != typeof(string))
                {
                    // Alt nesne için harita oluştur
                    cfg.CreateMap(sType, dType).MaxDepth(5).ReverseMap();

                    // Recursive: Alt nesnenin de altı varsa ona da bak (Örn: Brand -> Country)
                    AddSubMaps(cfg, sType, dType, depth + 1);
                }
            }
        }
    }
}