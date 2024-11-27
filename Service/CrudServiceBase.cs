using AppCrudWeb.Model;

namespace AppCrudWeb.Service
{
    public abstract class CrudServiceBase<TEntity,TDto>
        where TEntity : IEntity
    {
        public virtual TEntity Create(TDto dto)
        {
            var entity = MapToEntity(dto);
            entity = Insert(entity);
            return entity;
        }

        public virtual TEntity Read(int id)
        {
            var entity = Get(id);
            return entity;
        }


        public virtual TEntity Update(int id, TDto dto)
        {
            var entity = Get(id);
            if (entity == null) return default;
            entity = Modifica(entity, dto);

            return entity;
        }

        public virtual bool Delete(int id)
        {
            var entity = Get(id);
            if (entity == null) return false;
            Cancella(id);
            return true;
        }
        
        public virtual IEnumerable<TEntity> GetAll(int pageSize,int pageNumber)
        {
             var entities = OttieniTutti().OrderBy(e => e.Name).ToList();

             return entities
       .Skip((pageNumber - 1) * pageSize)
       .Take(pageSize)
       .ToList(); ;

        }
        

        protected abstract TEntity Insert(TEntity entity);
        protected abstract TEntity Get(int id);
        protected abstract TEntity Modifica(TEntity entity, TDto dto);
        protected abstract bool Cancella(int id);
        protected abstract IEnumerable<TEntity> OttieniTutti();
        //protected abstract IEnumerable<TEntity> GetPage(int pageNumber, int pageSize); 
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract TEntity MapToEntity(TDto dto);

    }
}
