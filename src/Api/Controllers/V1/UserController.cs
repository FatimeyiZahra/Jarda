using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Resources.User;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

       

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterResource resource)
        {
            if (_context.Users.Any(u => u.Email == resource.Email)) return Conflict(new
            {
                message = "This Email aready exists"
            });

            var user = _mapper.Map<RegisterResource, User>(resource);

            _context.Users.Add(user);

            _context.SaveChanges();

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginResource resource)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == resource.Email);

            if (user != null)
            {
                if (CryptoHelper.Crypto.VerifyHashedPassword(user.Password, resource.Password))
                {
                    user.Token = CryptoHelper.Crypto.HashPassword(DateTime.Now.ToString());

                    _context.SaveChanges();

                    var userResource = _mapper.Map<User, UserResource>(user);

                    return Ok(userResource);
                }
            }

            return NotFound(new
            {
                message = "Email or password incorrect"
            });
        }
    }
}
