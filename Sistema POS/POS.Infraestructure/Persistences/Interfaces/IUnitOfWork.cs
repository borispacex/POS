using POS.Infraestructure.FileStorage;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        // Declaracion o matricula de nuestra interfaces a nivel de repositorio
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IAzureStorage Storage { get; }
        IProviderRepository Provider { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
