using Common;
using DAL.Repository;
using System.Configuration;

namespace BLL.Service;

public class LoginService
{
    Repository<User> userRepository;

    public LoginService()
    {
        userRepository = new(ConfigurationManager.AppSettings["UserPath"]);
    }

    public List<User> LoginDetails()
    {
        return userRepository.GetAll();
    }

    public bool UserLogin(string matchEmail, string matchPassword)
    {
        List<User> users = LoginDetails();
        return users.Any(u => u.Username == matchEmail && u.Password == matchPassword);
    }

    public bool IsUserExists(string username)
    {
        List<User> users = LoginDetails();
        return users.Any(u => u.Username == username);
    }
}
