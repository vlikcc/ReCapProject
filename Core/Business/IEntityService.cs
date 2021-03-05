using Core.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Core.Business
{
    public interface IEntityService<T> where T : class, IEntity, new()
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entitiy);
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
      

    }
}
