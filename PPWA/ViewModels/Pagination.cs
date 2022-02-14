using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPWA.ViewModels
{
    public class Pagination
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
