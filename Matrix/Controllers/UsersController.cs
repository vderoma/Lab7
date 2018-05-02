using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Matrix.Data;
using Matrix.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    //[Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("User")]
        public async Task<UserInfoDetailedDTO> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userDetails = _mapper.Map<UserInfoDetailedDTO>(user);
            return userDetails;

        }

        [HttpGet("Users")]
        public async Task<IEnumerable<UserInfoBriefDTO>> GetUsers()
        {
            var users = await _repo.GetUsers();
            var allUsersDetails = _mapper.Map<IEnumerable<UserInfoBriefDTO>>(users);
            return allUsersDetails;
        }

        [HttpPut]
        [Route("/api/users/updateuser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updatedUser)
        {
            var user = await _repo.GetUser(id);
            user = _mapper.Map(updatedUser, user);
            await _repo.SaveAll();
            return NoContent();

        }
    }
}