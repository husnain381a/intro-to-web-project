using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OPEN_SKILLS_SOURCE__MVC_PROJECT_.Models;
using System.Collections.Generic; // Add this for List

namespace OPEN_SKILLS_SOURCE__MVC_PROJECT_.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        // Static list to store form submissions
        private static List<(string Name, string Email, string Message)> SubmittedData = new();

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        // GET: /Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Contact/SubmitForm
        [HttpPost]
        public IActionResult SubmitForm(string Name, string Email, string Message)
        {
            // Validate form data
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Message))
            {
                ViewBag.Message = "All fields are required.";
                return View("Index");
            }

            // Store data in static list
            SubmittedData.Add((Name, Email, Message));

            // Log form submission
            _logger.LogInformation($"Contact form submitted by {Name} with email {Email}. Message: {Message}");

            // Success message
            ViewBag.Message = $"Thank you, {Name}. We have received your message!";
            return View("Index");
        }

        // Action to view the submitted data
        public IActionResult ViewSubmissions()
        {
            return View(SubmittedData);  // Pass the list to the view
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
