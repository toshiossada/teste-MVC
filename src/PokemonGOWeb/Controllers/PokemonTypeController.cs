using System.Web.Mvc;

namespace PokemonGOWeb.Controllers
{
    public class PokemonTypeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string word)
        {
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(int id)
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View("Index");
        }
    }
}