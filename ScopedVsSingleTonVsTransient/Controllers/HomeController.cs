using Microsoft.AspNetCore.Mvc;
using ScopedVsSingleTonVsTransient.Models;
using System.Diagnostics;

namespace ScopedVsSingleTonVsTransient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransient _transientService1;
        private readonly ITransient _transientService2;
        private readonly IScoped _scopedService1;
        private readonly IScoped _scopedService2;
        private readonly ISingleTon _singletonService1;
        private readonly ISingleTon _singletonService2;
        public HomeController(ILogger<HomeController> logger,
            ITransient transientService1,
            ITransient transientService2,
            IScoped scopedService1,
            IScoped scopedService2,
            ISingleTon singletonService1,
            ISingleTon singletonService2)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

      
        public IActionResult Index()
        {
            ViewBag.transient1 = _transientService1.GetOperationID().ToString();
            ViewBag.transient2 = _transientService2.GetOperationID().ToString();
            ViewBag.scoped1 = _scopedService1.GetOperationID().ToString();
            ViewBag.scoped2 = _scopedService2.GetOperationID().ToString();
            ViewBag.singleton1 = _singletonService1.GetOperationID().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationID().ToString();
            return View();
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