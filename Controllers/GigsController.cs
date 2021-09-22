using GitHub.Models;
using GitHub.ViewsModel;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GitHub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);


            }

            var artistId = User.Identity.GetUserId();
          

            var gig = new Gig
            {
                ArtistId = artistId,
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue



            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");



        }

    }
}