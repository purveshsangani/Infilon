using Practical1.Manager;
using System.Web.Mvc;

namespace infilon.Practical1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOddTableManager oddTableManager;
        private readonly IEvenTableManager evenTableManager;
        private readonly IHistoryTableManager historyTableManager;

        public HomeController()
        {
            oddTableManager = new OddTableManager();
            evenTableManager = new EvenTableManager();
            historyTableManager = new HistoryTableManager();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Even()
        {
            return View();
        }

        // GET: Home
        public ActionResult History()
        {
            return View();
        }

        public JsonResult GetOddList()
        {
            var data = oddTableManager.Search();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveOdd(string id, string title, string status)
        {
            var data = oddTableManager.GetByKey(int.Parse(id));
            if (data != null)
            {
                data.Title = title;
                data.Completed = bool.Parse(status);
                oddTableManager.Save(data);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteOddRecord(string id)
        {
            var data = oddTableManager.GetByKey(int.Parse(id));
            if (data != null)
            {
                oddTableManager.Remove(data);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEvenList()
        {
            var data = evenTableManager.Search();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEven(string id, string title, string status)
        {
            var data = evenTableManager.GetByKey(int.Parse(id));
            if (data != null)
            {
                data.Title = title;
                data.Completed = bool.Parse(status);
                evenTableManager.Save(data);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteEvenRecord(string id)
        {
            var data = evenTableManager.GetByKey(int.Parse(id));
            if (data != null)
            {
                evenTableManager.Remove(data);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetHistoryList()
        {
            var data = historyTableManager.Search();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}