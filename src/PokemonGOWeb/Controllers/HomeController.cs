using PokemonGOCore.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PokemonGOWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}