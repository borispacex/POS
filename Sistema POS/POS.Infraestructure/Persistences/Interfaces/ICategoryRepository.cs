using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Request;
using POS.Infraestructure.Commons.Bases.Response;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);

    }
}
