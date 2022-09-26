using AspCoreBE.Context;
using AspCoreBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                return Ok(_context.Users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// GET /[controller]/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var data = _context.Users.FirstOrDefault(u => u.Id.Equals(id));
                return data == null ? NotFound() : data;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// POST /[controller]
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public ActionResult<User> Add([FromBody] User value)
        {
            try
            {
                _context.Users.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Add), value);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// PUT /[controller]/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public ActionResult<User> Edit(int id, [FromBody] User value)
        {
            try
            {
                if (!id.Equals(value.Id)) return BadRequest();

                var user = _context.Users.FirstOrDefault(s => s.Id.Equals(id));
                if (user == null) return NotFound();

                _context.Entry<User>(user).CurrentValues.SetValues(value);
                _context.SaveChanges();
                return Ok(value);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// DELETE /[controller]/{id}
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(s => s.Id == id);
                if (user == null) return NotFound();

                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
