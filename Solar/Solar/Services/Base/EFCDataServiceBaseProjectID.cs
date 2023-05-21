using Microsoft.EntityFrameworkCore;
public abstract class EFCDataServiceBaseProjectID<T> : IDataServiceProjectID<T> where T : class, IHasProjectId
{
	public int Create(T entity)
	{
		using DbContext context = CreateDBContext();

		context.Set<T>().Add(entity);
		context.SaveChanges();

		return entity.ProjectId;
	}

	public T? Read(int projectId)
	{
		using DbContext context = CreateDBContext();

		return GetAllWithIncludes(context).FirstOrDefault(x => x.ProjectId == projectId);
	}

	public void Update(T entity)
	{
		using DbContext context = CreateDBContext();

		context.Update(entity);
	}

	public void Delete(int projectId)
	{
		using DbContext context = CreateDBContext();

		context.Set<T>().Remove(context.Set<T>().Find(projectId));
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