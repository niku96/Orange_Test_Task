using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPWA.ViewModels
{
    public class IndexVM : Pagination
    {
        public List<PopularMovie> PopularMovies { get; set; }
    }

    public class PopularMovie
    {
        public int id { get; set; }
        public string original_title { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
    }
}
