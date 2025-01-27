
using Api.Repositories;
using System.Linq.Expressions;

namespace CardShapping.Api.RepositoryAPI.SerchRepository
{
    public interface ISearchRepository<T> : IBaseRepository<T> where T : class

    {
       
        Task<IQueryable<T>> ReadAllAsyncSerchName(Expression<Func<T,bool>> filter,string  Typecolumn);
        Task<IQueryable<T>>SerchasyncId(Expression<Func<T,bool>> filter,int id);

    }
}
