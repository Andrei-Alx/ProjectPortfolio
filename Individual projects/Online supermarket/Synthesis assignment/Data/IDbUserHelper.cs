namespace Data
{
    public interface IDbUserHelper
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO? FindUser(string name, string password);
		UserDTO? FindUser(string name);
		UserDTO? GetUserByID(int id);
        UserDTO? GetUserByName(string name);
        void CreateUser(string name, string password, string role);
    }
}