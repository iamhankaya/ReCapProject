using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IService<T> where T : class,IEntity,new()
    {
        DataResult<List<T>> GetAll();
        Result Add(T entity);
        Result Update(T entity);
        Result Delete(T entity);
       
    }
}
