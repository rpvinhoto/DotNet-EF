using System.Web.Mvc;

namespace ProjetoLivraria.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Renato Plaça Vinhoto";

            return View();
        }
    }
}