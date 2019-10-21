using KonusarakOgren.Business.Services.Interfaces;
using KonusarakOgren.Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KonusarakOgren.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return BadRequest(false);
            }

            if(!_accountService.Login(username, password))
            {
                return BadRequest(false);
            }

            return RedirectToAction("Create", "Exam");
        }
    }
}