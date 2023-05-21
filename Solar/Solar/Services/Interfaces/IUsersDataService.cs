public interface IUsersDataService : IDataService<User> 
{
	User? VerifyUser(string username, string password);

	bool CheckUsernameExist(string username);
}