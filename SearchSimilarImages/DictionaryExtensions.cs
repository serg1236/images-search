using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchSimilarImages
{
    static class DictionaryExtension
    {
        public static T Get<K, T>(this Dictionary<K, T> dictionary, K key)
        {
            T value;
            dictionary.TryGetValue(key, out value);
            return value;
        }

        public static T GetEquals<K, T>(this Dictionary<K, T> dictionary, K key)
        {
            return dictionary.Where(x => x.Key.Equals(key)).ElementAt(0).Value;
        }
    }
}
