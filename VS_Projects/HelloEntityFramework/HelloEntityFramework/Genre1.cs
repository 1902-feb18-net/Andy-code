using System;
using System.Collections.Generic;

namespace HelloEntityFramework
{
    public partial class Genre1
    {
        public Genre1()
        {
            Movie = new HashSet<Movie>();
            Track = new HashSet<Track>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
        public virtual ICollection<Track> Track { get; set; }
    }
}
