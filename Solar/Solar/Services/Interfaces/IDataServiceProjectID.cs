public interface IDataServiceProjectID<T> where T : class, IHasProjectId
{
	int Create(T entity);
	T? Read(int projectId);
	void Update(T entity);
	void Delete(int projectId);
	List<T> GetAll();
}