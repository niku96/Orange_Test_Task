using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLibray.Models
{
    public class FavoriteMovie
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int TmdbId { get; set; }
    }
}
