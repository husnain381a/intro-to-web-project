using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq; // For LINQ queries
using OPEN_SKILLS_SOURCE__MVC_PROJECT_.Models;
using OPEN_SKILLS_SOURCE__MVC_PROJECT_.Data;

namespace OPEN_SKILLS_SOURCE__MVC_PROJECT_.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbcontext _context;
        private readonly ILogger<ContactController> _logger;

        public ContactController(AppDbcontext context, ILogger<ContactController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Contact/SubmitForm
       
        [HttpPost]
        public IActionResult SubmitForm(ContactForms contactForm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Please fill out all fields correctly.";
                return View("Index");
            }
            // Save data to the database
            _context.ContactForms.Add(contactForm);
            _context.SaveChanges();

            // Display confirmation message
            ViewBag.Message = "Thank you for your message!";
            ViewBag.SubmittedData = contactForm; // Display submitted data
            return View("Index");
        }


        //// GET: /Contact/ViewSubmissions
        //public IActionResult ViewSubmissions()
        //{
        //    // Retrieve all data from the database
        //    var submissions = _context.ContactForms.ToList();

        //    // Pass the data to the view
        //    return View(submissions);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
