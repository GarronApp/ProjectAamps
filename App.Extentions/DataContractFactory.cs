using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace App.Extentions
{
    public static class DataContractFactory
    {
        private static ConcurrentDictionary<string, DataContractSerializer> Cache = new ConcurrentDictionary<string, DataContractSerializer>();

        public static DataContractSerializer Create(Type type)
        {
            var key = "{0}".FormatInvariantCulture(type.FullName);

            if (!Cache.ContainsKey(key))
            {
                Cache.TryAdd(key, new DataContractSerializer(type, null, int.MaxValue, false, false, new DataContractSurrogate()));
            }

            return Cache[key];
        }
    }
}
