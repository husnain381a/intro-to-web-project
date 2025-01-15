using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OPEN_SKILLS_SOURCE__MVC_PROJECT_.Data;
using OPEN_SKILLS_SOURCE__MVC_PROJECT_.Models;

namespace OPEN_SKILLS_SOURCE__MVC_PROJECT_.Controllers
{
    public class ReviewsController : Controller
    {
         
        private readonly AppDbcontext _context; 
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(ILogger<ReviewsController> logger, AppDbcontext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Home/Index
        public IActionResult Index1R()
        {
            var reviews = _context.Reviews.ToList(); // Fetch all reviews from the database
            return View(reviews); // Pass the reviews to the Index view
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View(); // Show the Create form
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reviews review)
        {
            if (ModelState.IsValid)
            {
                review.CreatedAt = DateTime.Now; // Set the current timestamp for the review
                _context.Reviews.Add(review); // Add the review to the DbContext
                _context.SaveChanges(); // Save the changes to the database
                return RedirectToAction("Index1R"); 
            }
            return View(review); // If the form is invalid, return to the Create view
        }

        // GET: Home/Edit/{id}
        public IActionResult Edit(int id)
        {
            var review = _context.Reviews.Find(id); // Find the review by its ID
            if (review == null)
                return NotFound(); // Return 404 if the review is not found

            return View(review); // Pass the review to the Edit view
        }

        // POST: Home/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reviews review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Update(review); // Update the review in the DbContext
                _context.SaveChanges(); // Save the changes to the database
                return RedirectToAction("Index1R"); // Redirect to the index page after updating
            }
            return View(review); // If the form is invalid, return to the Edit view
        }

        // GET: Home/Delete/{id}
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Find(id); // Find the review by its ID
            if (review == null)
                return NotFound(); // Return 404 if the review is not found

            return View(review); // Pass the review to the Delete view
        }

        // POST: Home/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var review = _context.Reviews.Find(id); // Find the review by its ID
            if (review != null)
            {
                _context.Reviews.Remove(review); // Remove the review from the DbContext
                _context.SaveChanges(); // Save the changes to the database
            }
            return RedirectToAction("Index"); // Redirect to the index page after deletion
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

