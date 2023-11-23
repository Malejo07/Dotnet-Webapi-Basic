using System.Linq.Expressions;

namespace MyVaccine.WebApi.Repositories.Contracts
{
    public interface IBaseRepository<T>
    {
        Task Add(T entity);//agregar
        Task AddRange(List<T> entity);//agregar una lista de objetos o registros
        Task Update(T entity);//actulizar
        Task UpdateRange(List<T> entity);
        Task Delete(T entity);//eliminar
        Task DeleteRange(List<T> entity);//eliminar una lista de registros
        IQueryable<T> GetAll();//obtener todo
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Patch(T entity);//actualizar solo una o varias propiedades de un registro
        Task PatchRange(List<T> entities);
        IQueryable<T> FindByAsNoTracking(Expression<Func<T, bool>> predicate);
    }
}