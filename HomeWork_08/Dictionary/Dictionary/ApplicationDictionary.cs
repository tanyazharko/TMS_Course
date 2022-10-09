using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class ApplicationDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictionary;

        public ApplicationDictionary()
        {
            _dictionary = new Dictionary<TKey, TValue>();
        }
        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }

        public void Remove(TKey key)
        {
            _dictionary.Remove(key, out TValue value);
        }

        public void ListOfKey()
        {
            foreach (var temp in _dictionary)
            {
                Console.WriteLine(temp.Key);
            }
        }

        public TValue GetValueByKey(TKey key)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary.TryGetValue(key, out TValue? value);

                return value;
            }
            else
            {
                throw new Exception("This key is not in the dictionary");
            }
        }
    }
}
