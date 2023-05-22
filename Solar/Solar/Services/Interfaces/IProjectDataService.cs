
public interface IProjectDataService : IDataService<Project>
{
	public List<Project> SortByStatus(int statusId);
}