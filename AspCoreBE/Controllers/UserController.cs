using Microsoft.AspNetCore.Mvc;

namespace AspCoreBE.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet("one")]
        public string GetOne()
        {
            return "one";
        }
    }
}
