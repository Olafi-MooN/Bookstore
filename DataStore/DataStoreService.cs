
using System.Collections.Generic;
using Bookstore.Entity;

namespace Bookstore.DataStore;

public class DataStoreDefaultProps
{
    public Guid Id { get; set; } = Guid.NewGuid();
}


public class DataStoreService<T> : IDataStore<T> where T : DataStoreDefaultProps
{
    private static Dictionary<string, List<T>> _dictionary = new Dictionary<string, List<T>>();
    private readonly string _classeNameActual = typeof(Book).Name;

    public void Create(T item)
    {
        if (!_dictionary.ContainsKey(_classeNameActual))
            _dictionary.TryAdd(_classeNameActual, new List<T>());

        if (_dictionary.TryGetValue(_classeNameActual, out List<T>? _items))
        {
            if (_items.Any(x => x.Id == item.Id))
                throw new Exception("Já existe um usuário com esse nome");

            _items.Add(item);
        }
    }

    public void Delete(T item)
    {

        if (!_dictionary.ContainsKey(_classeNameActual))
            throw new Exception($"Não é possivel encontrar a classe: {_classeNameActual}");

        if (_dictionary.TryGetValue(_classeNameActual, out List<T>? _items))
        {
            _items.Remove(item);
        }

    }

    public T? Get(Guid id)
    {
        if (!_dictionary.ContainsKey(_classeNameActual))
            throw new Exception($"Não é possivel encontrar a classe: {_classeNameActual}");

        if (_dictionary.TryGetValue(_classeNameActual, out List<T>? _items))
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        return null;
    }

    public IEnumerable<T>? GetAll()
    {
        if (!_dictionary.ContainsKey(_classeNameActual))
            throw new Exception($"Não é possivel encontrar a classe: {_classeNameActual}");

        if (_dictionary.TryGetValue(_classeNameActual, out List<T>? _items))
        {
            return _items;
        }

        return null;
    }

    public void Update(T item)
    {
        if (!_dictionary.ContainsKey(_classeNameActual))
            throw new Exception($"Não é possivel encontrar a classe: {_classeNameActual}");

        if (_dictionary.TryGetValue(_classeNameActual, out List<T>? _items))
        {
            var existingItem = _items.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem != null)
            {
                _items.Remove(existingItem);
                _items.Add(item);
            }
        }
    }
}
