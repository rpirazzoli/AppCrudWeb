using AppCrudWeb.Model;
using AppCrudWeb.Dto;

namespace AppCrudWeb.Service
{
    public class UserService : CrudServiceBase<User, UserDto>
    {
        private static List<User> repository = new List<User>
    {
        new User { Id = 1, Name = "zyx@", Email = "@@" },
        new User { Id = 2, Name = "abc@", Email = "@@" }
    };
        private int _idCounter = repository.Max(x => x.Id) + 1;


        protected override User Insert(User entity)
        {
            entity.Id = _idCounter++;
            repository.Add(entity);
            return entity;
        }

        protected override User Get(int id)
        {
            var entity = repository.FirstOrDefault(x => x.Id == id);
            return entity != null ? entity : default;
        }

        protected override User Modifica(User entity, UserDto dto)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            return entity;
        }

        protected override IEnumerable<User> OttieniTutti()
        {
            return repository;
        }
      


        protected override bool Cancella(int id)
        {
            var entity = Get(id);

            repository.Remove(entity);
            return true;
        }

        //-------------------------------

        protected override User MapToEntity(UserDto dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,


            };
        }
        protected override UserDto MapToDto(User entity)
        {
            return new UserDto
            {
                Name = entity.Name,
                Email = entity.Email
            };
        }

        
    }
}
