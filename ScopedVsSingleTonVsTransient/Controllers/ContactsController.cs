using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScopedVsSingleTonVsTransient.Controllers
{
    public class ContactsController : Controller
    {

        private readonly ILogger<ContactsController> _logger;
        private readonly ITransient _transientService1;
        private readonly ITransient _transientService2;
        private readonly IScoped _scopedService1;
        private readonly IScoped _scopedService2;
        private readonly ISingleTon _singletonService1;
        private readonly ISingleTon _singletonService2;

        /*
         * SingleTon: Service Request Instance Same through out the life time of an application Ex:Logging
         * Transient: Service Request Instance will be new every time.  Ex:Downstream service calling
         * Scoped: Service Request Instance Will remains same in the same scope, It will be New if it is new scope. Ex:Db Realted
         */

        public ContactsController(ILogger<ContactsController> logger,
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

        // GET: ContactsController
        public ActionResult Index()
        {
            ViewBag.transient1 = _transientService1.GetOperationID().ToString();
            ViewBag.transient2 = _transientService2.GetOperationID().ToString();
            ViewBag.scoped1 = _scopedService1.GetOperationID().ToString();
            ViewBag.scoped2 = _scopedService2.GetOperationID().ToString();
            ViewBag.singleton1 = _singletonService1.GetOperationID().ToString();
            ViewBag.singleton2 = _singletonService2.GetOperationID().ToString();
            return View();
        }

        // GET: ContactsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
