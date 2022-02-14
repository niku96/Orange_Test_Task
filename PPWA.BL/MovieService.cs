using Microsoft.EntityFrameworkCore;
using ModelsLibray;
using ModelsLibray.JsonObjects;
using PPWA.BL.Interfaces;
using PPWA.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using ModelsLibray.Models;


namespace PPWA.BL
{

    public class MovieService : IMovieInterface
    {
        private readonly ApplicationDbContext _context;


        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }



        public void AddToFavorite(int? MovieId, string userId)
        {

            var movieDetail = API.GetDetailMovie(MovieId);
            FavoriteMovie favoriteMovie = new FavoriteMovie();
            favoriteMovie.Id = Guid.NewGuid();
            favoriteMovie.Name = movieDetail.title;
            favoriteMovie.TmdbId = (int)MovieId;
            favoriteMovie.UserId = Guid.Parse(userId);

            _context.FavoriteMovies.Add(favoriteMovie);
            _context.SaveChanges();

            return;

        }



        public void DeleteFromFavorite(Guid? Id)
        {
            var favorite = _context.FavoriteMovies.Where(c => c.Id == Id).FirstOrDefault();
            _context.FavoriteMovies.Remove(favorite);
            _context.SaveChanges();
        }

        public Task<MoovieDetails.Root> GetDetailMovie(int? Id)
        {
            throw new NotImplementedException();
        }

        public  List<FavoriteMovie> GetFavorite(string userId)
        {
            Guid userid = Guid.Parse(userId);
            var movie =  _context.FavoriteMovies.Where(x => x.UserId == userid).ToList();


            return  movie;
        }

        public Task<MostPopularMovie.Root> GetMostPopularMovie(int? PageId)
        {
            throw new NotImplementedException();
        }

        public Task<TopRatedMovie.Root> GetTopRated(int? PageId)
        {
            throw new NotImplementedException();
        }

    }
}