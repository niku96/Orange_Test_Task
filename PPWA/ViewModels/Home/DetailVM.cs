using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPWA.ViewModels
{
    public class DetailVM
    {
                public int budget { get; set; }
                public List<string> genres { get; set; }
                public string homepage { get; set; }
                public int id { get; set; }
                public string original_title { get; set; }
                public string overview { get; set; }
                public double popularity { get; set; }
                public string poster_path { get; set; }
                public List<string> production_companies { get; set; }
                public List<string> production_countries { get; set; }
                public string release_date { get; set; }
                public string title { get; set; }
                public double vote_average { get; set; }
                public int vote_count { get; set; }
            }
        }

