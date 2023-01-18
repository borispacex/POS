using POS.Domain.Entities;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUserRepository :  IGenericRepository<User>
    {
        Task<User> AccountByUserName(string userName);

    }
}
