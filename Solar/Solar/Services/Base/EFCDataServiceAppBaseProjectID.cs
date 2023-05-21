using Microsoft.EntityFrameworkCore;
public class EFCDataServiceAppBaseProjectID<T> : EFCDataServiceBaseProjectID<T> where T : class, IHasProjectId
{
	protected override DbContext CreateDBContext()
	{
		return new SolarContext();
	}
}