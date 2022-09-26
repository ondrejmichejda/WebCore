using AspCoreBE.Context;
using AspCoreBE.Models;
using AspCoreBE.Repositories.User;
using AspCoreBE.Repositories.Wrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreBE.Controllers
{
    [Route("/[controller]")]
    public class UserController : Controller
    {
        private readonly IRepositoryWrapper repo;
        public UserController(IRepositoryWrapper repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// GET /[controller]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            try
            {
                return Ok(repo.Users.Get());
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
        public ActionResult<UserModel> Get(int id)
        {
            try
            {
                var data = repo.Users.Get(x => x.Id.Equals(id)).FirstOrDefault();
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
        public ActionResult<UserModel> Create([FromBody] UserModel value)
        {
            try
            {
                var newUser = repo.Users.Create(value);
                repo.Save();
                return CreatedAtAction(nameof(Create), newUser);
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
        public ActionResult<UserModel> Update(int id, [FromBody] UserModel value)
        {
            try
            {
                if (!id.Equals(value.Id)) return BadRequest();

                var user = repo.Users.Get(x => x.Id.Equals(id)).FirstOrDefault();
                if (user == null) return NotFound();

                var updatedUser = repo.Users.Update(value);
                repo.Save();

                return Ok(updatedUser);
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
                var userToDelete = repo.Users.Get(x => x.Id.Equals(id)).FirstOrDefault();
                if (userToDelete == null) return NotFound();

                repo.Users.Delete(userToDelete);
                repo.Save();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
