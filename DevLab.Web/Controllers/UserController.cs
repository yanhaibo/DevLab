using Microsoft.AspNetCore.Mvc;
using DevLab.Application.Services;

namespace DevLab.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.GetByIdAsync(id, HttpContext.RequestAborted);

            if (user == null)
            {
                // 重定向到自定义404页面
                return RedirectToAction("Error", "Home", new { statusCode = 404 });
            }

            return View(user);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
