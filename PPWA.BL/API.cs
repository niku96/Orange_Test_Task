using ModelsLibray.JsonObjects;
using Newtonsoft.Json;
using System.IO;
using System.Net;


namespace PPWA.BL
{
    public class API { 
        public static   MostPopularMovie.Root GetMostPopularMovie(int? PageId)
        {
            WebRequest request = WebRequest.Create("https://api.themoviedb.org/3/movie/popular?api_key=dad8a59d86a2793dda93aa485f7339c1&page=" + PageId);

            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";

            var response = (HttpWebResponse)request.GetResponse();
            MostPopularMovie.Root responsew = new MostPopularMovie.Root();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MostPopularMovie.Root root = JsonConvert.DeserializeObject<MostPopularMovie.Root>(result);
                responsew = root;
                response.Close();

            }
            return responsew;
        }

        public static MoovieDetails.Root GetDetailMovie(int? Id)
        {
            WebRequest request = WebRequest.Create("https://api.themoviedb.org/3/movie/" + Id + "?api_key=dad8a59d86a2793dda93aa485f7339c1");

            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";

            var response = (HttpWebResponse)request.GetResponse();
            MoovieDetails.Root responsew = new MoovieDetails.Root();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MoovieDetails.Root root = JsonConvert.DeserializeObject<MoovieDetails.Root>(result);
                responsew = root;
                response.Close();

            }
            return responsew;
        }

        public static TopRatedMovie.Root GetTopRated(int? PageId)
        {
            WebRequest request = WebRequest.Create("https://api.themoviedb.org/3/movie/top_rated?api_key=dad8a59d86a2793dda93aa485f7339c1&page=" + PageId);

            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";

            var response = (HttpWebResponse)request.GetResponse();
            TopRatedMovie.Root responsew = new TopRatedMovie.Root();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                TopRatedMovie.Root root = JsonConvert.DeserializeObject<TopRatedMovie.Root>(result);
                responsew = root;
                response.Close();

            }
            return responsew;
        }
    }
}
