using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            return View();
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult VerifyUserName(string UserName)
        {

            var users = new List<string> { "vahapunat", "vahabyte" };

            if (users.Any(i => i == UserName))
            {
               return Json($"{UserName} isimli kullanıcı adı kullanılıyor!");
            }
            return Json(true);
        }


    }
}
