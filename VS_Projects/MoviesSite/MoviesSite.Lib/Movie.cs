using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesSite.Lib
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre genre { get; set; }
        public DateTime DateReleased { get; set; }
    }
}
