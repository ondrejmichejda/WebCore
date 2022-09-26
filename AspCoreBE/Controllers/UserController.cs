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
        private WebCoreContext _context;
        public UserController(WebCoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /[controller]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        /// <summary>
        /// GET /[controller]/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        /// <summary>
        /// POST /[controller]
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        //[Route("/update")]
        //[HttpPost("{id}")]
        //public void Put(int id, [FromBody] User value)
        //{
        //    var user = _context.Users.FirstOrDefault(s => s.Id.Equals(id));
        //    if (user != null)
        //    {
        //        _context.Entry<User>(user).CurrentValues.SetValues(value);
        //        _context.SaveChanges();
        //    }
        //}

        /// <summary>
        /// PUT /[controller]
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var user = _context.Users.FirstOrDefault(s => s.Id.Equals(id));
            if (user != null)
            {
                _context.Entry<User>(user).CurrentValues.SetValues(value);
                _context.SaveChanges();
            }
        }

        //[Route("/delete")]
        //[HttpGet("{id}")]
        //public void Delete(int id)
        //{
        //    var user = _context.Users.FirstOrDefault(s => s.Id == id);
        //    if (user != null)
        //    {
        //        _context.Users.Remove(user);
        //        _context.SaveChanges();
        //    }
        //}

        /// <summary>
        /// DELETE /[controller]
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(s => s.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
