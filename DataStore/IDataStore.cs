namespace Bookstore.DataStore;

public interface IDataStore<T> where T : DataStoreDefaultProps
{
    IEnumerable<T>? GetAll();
    T? Get(Guid id);
    void Create(T item);
    void Update(T item);
    void Delete(T item);
}
