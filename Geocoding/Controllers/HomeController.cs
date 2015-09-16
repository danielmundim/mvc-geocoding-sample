using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Nonlinear.Models;

namespace Nonlinear.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();

            model.States = LoadEstates();
            model.Cities = Enumerable.Empty<SelectListItem>();

            return View(model);
        }

        private IEnumerable<SelectListItem> LoadEstates()
        {
            string path = HttpContext.Server.MapPath("~/App_Data/estados.xml");
            //
            IEnumerable<SelectListItem> states = from proc in XDocument.Load(path).Descendants("estado")
                                                  select new SelectListItem
                                                  {
                                                      Value = (string)proc.Element("idestado"),
                                                      Text = (string)proc.Element("nome")
                                                  };
            return states;
        }

        [HttpGet]
        public ActionResult LoadCities(int id)
        {
            string path = HttpContext.Server.MapPath("~/App_Data/cidades.xml");
            //
            var cities = (from proc in XDocument.Load(path).Descendants("cidade")
                            select new CityModel
                            {
                                Id = (int)proc.Element("idcidade"),
                                Nome = (string)proc.Element("nome"),
                                IdEstado = (int)proc.Element("idestado")
                            }).Where(a => a.IdEstado == id);

            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}
