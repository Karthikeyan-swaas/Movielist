using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies_list_ajax_model.moviesDb;
using Movies_list_ajax_model.Models;

namespace Movies_list_ajax_model.Controllers
{
    public class MoviesController : Controller
    {
        MoviesDb movDb = new MoviesDb();

        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult MovieList()
        {
            return Json(movDb.ListAll(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddMovie(Moviesmodel mov)
        {
            return Json(movDb.Add(mov), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetbyMovieID(int id)
        {
            var Employee = movDb.ListAll().Find(x => x.id.Equals(id));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(Moviesmodel mov)
        {
            return Json(movDb.Update(mov), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(int ID)
        {
            return Json(movDb.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }//hi karthik//
}
