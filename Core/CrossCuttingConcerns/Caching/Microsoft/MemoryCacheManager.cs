﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern
         IMemoryCache _memorCache;
         
        public MemoryCacheManager()
        {
            _memorCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public T Get<T>(string key)
        {
            return _memorCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memorCache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            _memorCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _memorCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memorCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memorCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memorCache.Remove(key);
            }
        }
    }
}
