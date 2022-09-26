using AspCoreBE.Context;
using AspCoreBE.Models;
using AspCoreBE.Repositories;
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
        private readonly UserRepository repo;
        public UserController(UserRepository repo)
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
                return Ok(repo.Get());
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
                var data = repo.Get(id);
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
        public ActionResult<UserModel> Add([FromBody] UserModel value)
        {
            try
            {
                return CreatedAtAction(nameof(Add), repo.Add(value));
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
        public ActionResult<UserModel> Edit(int id, [FromBody] UserModel value)
        {
            try
            {
                if (!id.Equals(value.Id)) return BadRequest();

                var user = repo.Get(id);
                if (user == null) return NotFound();

                return Ok(repo.Update(user));
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
                var user = repo.Get(id);
                if (user == null) return NotFound();

                repo.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
