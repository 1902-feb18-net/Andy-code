using MoviesSite.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesSite.App.Models
{
    /*
        * A view model is a type of model in the MVC pattern
        * that is tightly bound to a particular view
        * 
        * basically when the business logic models that we have in our app
        * don't match exactly what the view needs in order to have its data
        * then we make a new class meant for that view to use
        * 
        * often with layered architecture (multiple projects with separate concerns)
        * MVC laayer is not really using our business logic classes and definitely not our EF entity classess
        * instead using view models to be each view's model
    */
    public class MovieViewModel
    {
        public int Id { get; set; }

        /*
         * we use attributes from DataAnnotations Library to tell MVC
         * what things to check for automatic client-side validation
         * (Using JQuery unobtrusive JS library, behind the scene)
         * and server sde validation using ModelState
         */ 

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required] //default will not be accepted, although Datetime is weird
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        public List<Genre> Genres { get; set; }

        // here we can provice other info the view may need
        //public string LoggedInUser { get; set; }
        
    }
}
