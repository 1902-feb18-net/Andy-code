using System;
using System.Collections.Generic;

namespace HelloEntityFramework
{
    public partial class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
