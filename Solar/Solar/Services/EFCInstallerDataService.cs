using Microsoft.EntityFrameworkCore;

public class EFCInstallerDataService
{
	public void Create(Installer installer)
	{
		using DbContext dbContext = CreateDbContext();

		dbContext.Set<Installer>().Add(installer);
		dbContext.SaveChanges();
	}

	public Installer Read(int userId)
	{
		using DbContext dbContext = CreateDbContext();

		return dbContext.Set<Installer>().FirstOrDefault(x => x.UserId == userId);
	}
	private DbContext CreateDbContext()
	{
		return new SolarContext();
	}
}