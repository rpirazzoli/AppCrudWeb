﻿using AppCrudWeb.Model;
using AppCrudWeb.Service;
using Microsoft.AspNetCore.Mvc;
using AppCrudWeb.Dto;


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
        public ActionResult<UserDto> GetAll(int pageSize, int pageNumber,  string sort=null) //SORT DICHIARATO COMR NULL - SENNò NELLO SWAGGER IL SORT ERA OBBLIGATORIO
        {
            var user = _userService.GetAll(pageSize,pageNumber, sort);
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
            if (user == null) return NotFound();
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
