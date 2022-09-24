using AspCoreBE.Selectors;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreBE.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet("one")]
        public UserSelector GetOne()
        {
            return new UserSelector{ Id = 1 };
        }
    }
}
