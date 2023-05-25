using Microsoft.EntityFrameworkCore;

public class EFCProjectDataService : EFCDataServiceAppBase<Project>, IProjectDataService
{
	/// <inheritdoc />
	public List<Project> SortByStatus(int statusId)
	{
		throw new NotImplementedException();
	}

    protected override IQueryable<Project> GetAllWithIncludes(DbContext dbContext)
    {
		return dbContext.Set<Project>()
			.Include(x => x.Assembly)
			.Include(x => x.DimensioningConsumption)
			.Include(x => x.DimensioningkWp)
			.Include(x => x.Battery)
			.Include(x => x.BatteryRequest)
			.Include(x => x.Dimensioning)
			.Include(x => x.User)
			.Include(x => x.Assembly.RoofType);
    }
}