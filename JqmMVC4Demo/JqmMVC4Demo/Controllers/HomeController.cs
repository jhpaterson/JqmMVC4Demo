using System.Web.Mvc;

namespace JqmMVC4Demo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.HeaderString = "Welcome!";
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.HeaderString = "Create New Post";
            return View();
        }

        public ActionResult Read()
        {
            ViewBag.HeaderString = "Read Blog";

            return View();
        }

        public ActionResult ReadPost(int id)
        {
            ViewBag.HeaderString = "Read Post";
            ViewBag.ID = id;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.HeaderString = "About MobileBlog";
            return View();
        }

        // this shows alternative approach of loading data on server and passing to mobile view, instead
        // of loading data with ajax call from mobile view
        // just for illustration, doesn't link properly to other pages
        public ActionResult ReadServer()
        {
            var repository = new JqmMVC4Demo.Models.PostRepository();
            var posts = repository.GetAll();

            ViewBag.HeaderString = "Read Blog";

            return View(posts);
        }

    }
}
