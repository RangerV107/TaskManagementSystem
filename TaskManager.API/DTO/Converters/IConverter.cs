using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.API
{
    public interface IConverter<TEntity, TEntityDTO>
    {
        public TEntityDTO ToDTO(TEntity entity) /*=> throw new NotImplementedException();*/ { return default(TEntityDTO); }
        public List<Guid> ToDTO(List<TEntity> entities) => throw new NotImplementedException(); //{ return null; }
        public TEntity FromDTO(TEntityDTO entityDTO) => throw new NotImplementedException(); //{ return default(TEntity); }
        public List<TEntity> FromDTO(List<Guid> entityDTOs) => throw new NotImplementedException(); //{ return null; }
    }
}
