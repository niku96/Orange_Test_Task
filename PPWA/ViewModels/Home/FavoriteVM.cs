using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPWA.ViewModels
{
    public class FavoriteVM : Pagination
    {
        public List<FavoriteStruct> Favorites {get;set;}
    }

    public class FavoriteStruct
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int TmdbId { get; set; }
    }
}
