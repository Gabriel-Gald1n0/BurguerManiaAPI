using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurguerManiaAPI.Context;
using BurguerManiaAPI.Models;
using BurguerManiaAPI.Dto.User;
using BurguerManiaAPI.Interfaces.User;

namespace BurguerMania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _userInterface;

        public UsersController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }
        

        // GET: api/Users
        [HttpGet("GetUsers")]
        public async Task<ActionResult<ResponseModel<List<UsersModel>>>> GetUsers()
        {
            var users = await _userInterface.GetUsers();
            if (!users.Status && users.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = users.Mensagem  });
            }

            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<ResponseModel<UsersModel>>> GetUser(int id)
        {
            var user = await _userInterface.GetUser(id);
            if (!user.Status && user.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = user.Mensagem });
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutUsers/{id}")]
        public async Task<ActionResult<ResponseModel<UsersModel>>>  PutUsers(int id, UserRequest userRequest)
        {
            var user = await _userInterface.PutUsers(id, userRequest);
            if (!user.Status && user.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = user.Mensagem });
            }

            return Ok(user);
        }
        

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostUsers")]
        public async Task<ActionResult<UsersModel>> PostUsers(UserRequest userRequest)
        {
            var user = await _userInterface.PostUsers(userRequest);
            return Ok(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("delete/user/{id}")]
        public async Task<ActionResult<ResponseModel<UsersModel>>> DeleteUsers(int id)
        {
            var user = await _userInterface.DeleteUsers(id);
            if (!user.Status && user.StatusCode == 404)
            {
                return NotFound(new { status = 404, erros = user.Mensagem });
            }

            return Ok(user);
        }
    }
}
