using Microsoft.AspNet.Identity;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "FullName, Email, Message")] ContactViewModel contactModel)
        {
            if (ModelState.IsValid)
            {
                EmailService emailService = new EmailService();
                emailService.SendAsync(contactModel);
                return View(ActionName.CONTACT_CONFIRMATION, contactModel);
            }
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public FileResult DownloadResume()
        {
            return File("~/Downloads/ryan_fleming_resume.pdf", System.Net.Mime.MediaTypeNames.Application.Octet, "ryan_fleming_resume.pdf");
        }
    }
}