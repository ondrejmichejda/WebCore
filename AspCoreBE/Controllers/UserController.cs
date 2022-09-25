using AspCoreBE.Context;
using AspCoreBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreBE.Controllers
{
    [Route("/[controller]")]
    public class UserController : Controller
    {
        private DbSet<User> users;
        public UserController(WebCoreContext context)
        {
            users = context.Users;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return users.FirstOrDefault(u => u.Id.Equals(id));
        }
    }
}
