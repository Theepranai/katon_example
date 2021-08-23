using katon_example.Core.Services;
using katon_example.Web.Helper;
using katon_example.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace katon_example.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserServices _userService;

        public HomeController(
            ILogger<HomeController> logger,
            UserServices userServices
            )
        {
            _logger = logger;
            _userService = userServices;
        }

        public IActionResult Index()
        {
            var rto = _userService.GetAll();
            ViewData["edit"] = new UserModel()
            {
                Id = 0,
                Name = "",
                LastName = ""
            };
            return View(rto.ToEntity());
        }

        public IActionResult Edit(int id)
        {
            var editModel = _userService.GetById(id);

            ViewData["edit"] = new UserModel();

            if (id > 0 && editModel != null)
            {
                ViewData["edit"] = editModel.ToEntity();
            }

            var rto = _userService.GetAll();

            return View("Index", rto.ToEntity());
        }

        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            var modelDTO = model.ToDTO();

            if (string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.Name)) return Redirect("/home");

            if (model.Id == 0)
            {
                _userService.Add(modelDTO);
            }
            else
            {
                _userService.Edit(modelDTO);
            }

            return Redirect("/home");
        }

        public IActionResult Del(int id)
        {
            _userService.Delete(id);
            return Redirect("/home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
