using AWSBucket.Models.DataModel;
using AWSBucket.Services;
using System.Web.Mvc;

namespace AWSBucket.Controllers
{
    public class HomeController : Controller
    {
        private readonly S3Service service;
         public ActionResult Index()
        {
            var bucket = new Bucket();
            return View(bucket);
        }

        [HttpPost]
        public ActionResult Index(Bucket bucket)
        {
            service.AddBucket(bucket.BucketName);
            return RedirectToAction("Index", "Home");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}