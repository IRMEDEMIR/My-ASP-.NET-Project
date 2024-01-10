using Film.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Film.Service;


namespace Film.Controllers
{
    public class HomeController : Controller
    {
        private readonly IncelemelerService _incelemelerService; // IncelemelerService için bir örnek oluşturun

        public HomeController()
        {
            _incelemelerService = new IncelemelerService(); // Constructor içinde IncelemelerService örneğini oluşturun
        }
        public ActionResult Index()
        {
            yettiEntities2 entities = new yettiEntities2();

            List<Filmler> model = entities.Filmlers.OrderByDescending(item => item.ortalama_puan).ToList();

            return View(model);
        }
        public ActionResult Movies()
        {
            yettiEntities2 entities = new yettiEntities2();

            var grupluFilmler = entities.Filmlers.GroupBy(item => item.kategori);

            return View(grupluFilmler);
        }

        public ActionResult UserReviews()
        {
            using (var entities = new yettiEntities2())
            {
                List<Incelemeler> userReviews = entities.Incelemelers.ToList();

                foreach (var review in userReviews)
                {
                    var filmName = _incelemelerService.GetFilmName(review.film_id);

                    if (!string.IsNullOrEmpty(filmName))
                    {
                        review.Filmler.baslik = filmName; // Filmler ilişkisine film adını atayın
                    }
                }

                return View(userReviews); // Kullanıcı incelemeleri içinde Filmler ilişkisi doldurulmuş olacak
            }

        }

        public ActionResult AddReview()
        {
            return View();
        }


        public ActionResult SubmitReview(Incelemeler inceleme)
        {
            using (var context = new yettiEntities2())
            {
                if (ModelState.IsValid)
                {
                    context.Incelemelers.Add(inceleme);
                    try
                    {
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var eve in ex.EntityValidationErrors)
                        {
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine($"Property: {ve.PropertyName}, Error: {ve.ErrorMessage}");
                            }
                        }
                        throw;
                    }
                }
            }
            return View();
        }
    }
}