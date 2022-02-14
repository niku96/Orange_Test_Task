using ModelsLibray;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModelsLibray.JsonObjects;
using ModelsLibray.Models;
using System;

namespace PPWA.BL.Interfaces
{
    public interface IMovieInterface
    {
        
        public Task<MostPopularMovie.Root> GetMostPopularMovie(int? PageId);

        public Task<MoovieDetails.Root> GetDetailMovie(int? Id);

        public Task<TopRatedMovie.Root> GetTopRated(int? PageId);

        public void AddToFavorite(int? MovieId, string userId);

        public void DeleteFromFavorite(Guid? Id);

        List<FavoriteMovie> GetFavorite(string? userId);

    }
}
