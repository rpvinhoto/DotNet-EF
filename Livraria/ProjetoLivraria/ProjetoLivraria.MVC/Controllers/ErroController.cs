using System.Web.Mvc;

namespace ProjetoLivraria.MVC.Controllers
{
    public class ErroController : Controller
    {
        public ActionResult Index(string msg)
        {
            ViewBag.Message = msg;

            return View();
        }
    }
}