using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace STS_AU_NewGen_Siemens.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserInterface userInterface;
        public UserController(IUserInterface _userInterface)
        {
            userInterface = _userInterface;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                object o = await userInterface.LoginAsync(user);
                if (o != null)
                    return Ok(o);
                else
                    return Unauthorized();
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("GetEstimation")]
        public async Task<IActionResult> GetEstimation(Gold gold)
        {
            return Ok(await userInterface.GetEstimationAsync(gold));
        }
    }
}
