using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CustomViews.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace CustomViews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpcontextaccessor;
        private readonly ISession _session;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpcontextaccessor = httpContextAccessor;
            _session = _httpcontextaccessor.HttpContext.Session;
        }

        public IActionResult Index()
        {

            var f = _httpcontextaccessor.HttpContext.Request.Headers["User-Agent"].ToString();
            return View();
        }

        public IActionResult ToMobile()
        {
            _session.SetString("Device", "Mobile");

            return RedirectToAction("Index");
        }

        public IActionResult ToTablet()
        {
            _session.SetString("Device", "Tablet");

            return RedirectToAction("Index");
        }

        public IActionResult ToDesktop()
        {
            _session.SetString("Device", "Desktop");

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
