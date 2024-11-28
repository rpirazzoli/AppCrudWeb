using System.Reflection;
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

        public virtual IEnumerable<TEntity> GetAll(int pageSize, int pageNumber, string sort)
        {
            var entities = OttieniTutti();

            // ordina in base a sort
            if (!string.IsNullOrEmpty(sort))
            {                                                   //CASE SENSITIVE       //SOLO PROPRIETA PUBLICHE    SOLO VARIABILI D'ISTANZA
                var sortProperty = typeof(TEntity).GetProperty(sort, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (sortProperty != null)
                {
                    entities = entities.OrderBy(e => sortProperty.GetValue(e, null));
                }
            }

            else
            {
                //se sort è nullo o vuoto ordina per ID
                entities = entities.OrderBy(e => e.Id);
                
            }

            if (pageSize == 0)
                return entities.ToList();


            return entities
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }



        


        protected abstract TEntity Insert(TEntity entity);
        protected abstract TEntity Get(int id);
        protected abstract TEntity Modifica(TEntity entity, TDto dto);
        protected abstract bool Cancella(int id);
        protected abstract IEnumerable<TEntity> OttieniTutti();
        protected abstract TDto MapToDto(TEntity entity);
        protected abstract TEntity MapToEntity(TDto dto);

    }
}
