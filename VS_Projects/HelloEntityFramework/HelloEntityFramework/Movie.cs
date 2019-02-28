using System;
using System.Collections.Generic;

namespace HelloEntityFramework
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateModified { get; set; }
        public int GenreId { get; set; }
        public string FullName { get; set; }

        public virtual Genre1 Genre { get; set; }
    }
}
