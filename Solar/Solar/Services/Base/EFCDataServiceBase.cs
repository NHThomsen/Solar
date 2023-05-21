using Microsoft.EntityFrameworkCore;
public abstract class EFCDataServiceBase<T> : IDataService<T> where T : class, IHasID
{
	public virtual int Create(T entity)
	{
		using DbContext context = CreateDBContext();

		context.Set<T>().Add(entity);
		context.SaveChanges();

		return entity.Id;
	}

	public virtual T? Read(int id)
	{
		using DbContext context = CreateDBContext();

		return GetAllWithIncludes(context).FirstOrDefault(x => x.Id == id);
	}

	public void Update(T entity)
	{
		using DbContext context = CreateDBContext();

		context.Update(entity);
	}

	public void Delete(int id)
	{
		using DbContext context = CreateDBContext();

		context.Set<T>().Remove(context.Set<T>().Find(id));
	}

	public List<T> GetAll()
	{
		using DbContext context = CreateDBContext();

		return GetAllWithIncludes(context).ToList();
	}

	protected abstract DbContext CreateDBContext();

	protected virtual IQueryable<T> GetAllWithIncludes(DbContext dbContext) 
	{
		return dbContext.Set<T>();
	}
}