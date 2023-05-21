using Microsoft.EntityFrameworkCore;

public class EFCDataServiceAppBase<T> : EFCDataServiceBase<T> where T : class, IHasID
{
	protected override DbContext CreateDBContext()
	{
		return new SolarContext();
	}
}