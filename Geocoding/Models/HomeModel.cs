using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nonlinear.Models
{
    public class HomeModel
    {
        [Required]
        [Display(Name = "State/Province")]
        public IEnumerable<SelectListItem> States { get; set; }
        public int StateId { get; set; }

        [Required]
        [Display(Name = "City")]
        public IEnumerable<SelectListItem> Cities { get; set; }
        public int CityId { get; set; }
    }
}
