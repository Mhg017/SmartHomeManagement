using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomDictionary<TKey, TValue>
{
    private Dictionary<TKey, TValue> dictionary;

    public CustomDictionary()
    {
        dictionary = new Dictionary<TKey, TValue>();
    }

    public void Add(TKey key, TValue value)
    {
        dictionary[key] = value;
    }

    public void Update(TKey key, TValue value)
    {
        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = value;
        }
    }

    public void Remove(TKey key)
    {
        dictionary.Remove(key);
    }

    public TValue Get(TKey key)
    {
        return dictionary.ContainsKey(key) ? dictionary[key] : default(TValue);
    }

    public bool ContainsKey(TKey key)
    {
        return dictionary.ContainsKey(key);
    }

    public ICollection<KeyValuePair<TKey, TValue>> GetAllItems()
    {
        return dictionary;
    }
}