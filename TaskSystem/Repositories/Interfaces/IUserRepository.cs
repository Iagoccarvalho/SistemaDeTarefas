using TaskSystem.Model;

namespace TaskSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> findAllUsers();
        Task<User> findById(int id);
        Task<User> add(User user);
        Task<User> update(User user, int id);
        Task<bool> remove(int id);
    }
}
