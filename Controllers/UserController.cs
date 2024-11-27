using AppCrudWeb.Model;
using AppCrudWeb.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppCrudWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //operazione Read (GET) - restituisce singolo utente per ID
        [HttpGet("Get/{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var user = _userService.Read(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //operazione Read (GETALL) - restituisce tutti gli utenti
        [HttpGet("GetAll")]
        public ActionResult<UserDto> GeAll()
        {
            var user = _userService.GetAll();
            return Ok(user);
        }

        //operazione Create (POST) - crea nuovo utente
        [HttpPost("Create")]
        public ActionResult<UserDto> CreateUser(UserDto userDto)
        {
            var user = _userService.Create(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        //operazione Update (PUT) - aggiorna utente per id
        [HttpPut("Update/{id}")]
        public ActionResult<UserDto> UpdateUser(int id, UserDto userDto)
        {

            var user = _userService.Update(id, userDto);
            if (UpdateUser == null) return NotFound();
            return Ok(user);
        }

        //operazione Delete (DELETE) - Elimina utente per id
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteProduct(int id)
        {

            var success = _userService.Delete(id);
            if (!success) return NotFound();
            return Ok();
        }

    }
}
