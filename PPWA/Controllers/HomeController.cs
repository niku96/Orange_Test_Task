using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibray.Models;
using PPWA.BL;
using PPWA.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PPWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieService _movieService;

        public HomeController(MovieService movieService)
        {
            _movieService = movieService;
        }


        public async Task<IActionResult> GetFavorite()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favoriteList = _movieService.GetFavorite(userId);
            FavoriteVM favoriteVM = new FavoriteVM();
            List<FavoriteStruct> favorites = new List<FavoriteStruct>();
            foreach(var item in favoriteList)
            {
                favorites.Add(new FavoriteStruct
                {
                    Id = item.Id,
                    Name = item.Name,
                    TmdbId = item.TmdbId
                });
            }
            favoriteVM.Favorites = favorites;
   
            return View(favoriteVM);
        }
        public async Task<IActionResult> IndexAsync(int? page)
        {
            var responsew = API.GetMostPopularMovie(page);
            IndexVM indexVM = new IndexVM();
            List<PopularMovie> popular = new List<PopularMovie>();
            foreach (var item in responsew.results)
            {
                popular.Add(new PopularMovie
                {
                    id = item.id,
                    original_title = item.original_title,
                    name = item.title,
                    popularity = item.popularity,
                    overview = item.overview,
                    poster_path = item.poster_path
                }
                );
            }
            indexVM.page = responsew.page;
            indexVM.total_pages = responsew.total_pages;
            indexVM.PopularMovies = popular;

            return View(indexVM);
        }

        public async Task<IActionResult> GetTopRated(int? page)
        {
            var responsew = API.GetTopRated(page);
            IndexVM indexVM = new IndexVM();
            List<PopularMovie> popular = new List<PopularMovie>();
            foreach (var item in responsew.results)
            {
                popular.Add(new PopularMovie
                {
                    id = item.id,
                    original_title = item.original_title,
                    name = item.title,
                    popularity = item.popularity,
                    overview = item.overview,
                    poster_path = item.poster_path
                }
                );
            }
            indexVM.page = responsew.page;
            indexVM.total_pages = responsew.total_pages;
            indexVM.PopularMovies = popular;
            return View(indexVM);
        }

        public async Task<IActionResult> GetDetail(int? Id)
        {
            var responsew = API.GetDetailMovie(Id);
            DetailVM detailVM = new DetailVM();
            detailVM.homepage = responsew.homepage;
            detailVM.title = responsew.title;
            detailVM.original_title = responsew.original_title;
            detailVM.overview = responsew.overview;
            detailVM.budget = responsew.budget;
            detailVM.id = responsew.id;
            detailVM.popularity = responsew.popularity;
            detailVM.poster_path = responsew.poster_path;
            detailVM.release_date = responsew.release_date;
            detailVM.vote_average = responsew.vote_average;
            detailVM.vote_count = responsew.vote_count;
            List<string> lists = new List<string>();
            foreach(var item in responsew.genres)
            {
                lists.Add(item.name);
            }
            detailVM.genres = lists;
            lists.Clear();

            foreach (var item in responsew.production_companies)
            {
                lists.Add(item.name);
            }
            detailVM.production_companies = lists;
            lists.Clear();

            foreach (var item in responsew.production_countries)
            {
                lists.Add(item.name);
            }
            detailVM.production_countries = lists;
            lists.Clear();

            return View(detailVM);
        }

        public void AddToFavorite(int? Id) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _movieService.AddToFavorite(Id, userId);
            return;
        }


        public void DeleteFavorite(Guid? Id)
        {
            _movieService.DeleteFromFavorite(Id);
            return;
        }
    }
}
