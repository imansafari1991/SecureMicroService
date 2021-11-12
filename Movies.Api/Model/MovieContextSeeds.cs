using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Model
{
    public class MovieContextSeeds
    {

        public static void SeedAsync(MovieDBContext movieDBContext)
        {
            if(  !movieDBContext.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption2",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption4",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption3",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption5",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption6",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption7",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },
                    new Movie
                    {
                        Genre="Drama",
                        Title="The Shawshank Redemption8",
                        Rating="9.3",
                        ImageUrl="images/src",
                        ReleaseDate=new DateTime(1994,5,5),
                        Owner="alice"

                    },

                };
                movieDBContext.AddRange(movies);
                movieDBContext.SaveChanges();

            }
        }
    }
}
