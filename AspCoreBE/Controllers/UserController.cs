using AspCoreBE.Context;
using AspCoreBE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreBE.Controllers
{
    [Route("/[controller]")]
    public class UserController : Controller
    {
        private WebCoreContext _context;
        public UserController(WebCoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users?.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
