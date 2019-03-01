﻿using System;
using System.Collections.Generic;

namespace Entity3Database
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Genre Genre { get; set; }
    }
}