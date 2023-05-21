public interface IDataService<T> where T : class, IHasID
{
	int Create(T entity);
	T? Read(int id);
	void Update(T entity);
	void Delete(int id);
	List<T> GetAll();
}