using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingExample.Application
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository Repository;

        public ReviewService(IReviewRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentException("Missing repository");
            }
            Repository = repository;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            BEReview[] fakeRepo = Repository.GetAll();

            var counts = new Dictionary<int, int>();

            foreach (var item in fakeRepo)
            {
                int count;
                counts.TryGetValue(item.Reviewer, out count);
                count++;
                //Automatically replaces the entry if it exists;
                //no need to use 'Contains'
                counts[item.Reviewer] = count;
            }

            List<int> result = new List<int>();

            foreach (var item in counts)
            {
                if (result.Count == 0)
                {
                    result.Add(item.Key);
                }
                else
                {
                    int i;
                    counts.TryGetValue(result.ElementAt(0),out i);

                    if (item.Value > i)
                    {
                        result.Clear();
                        result.Add(item.Key);
                    }
                    else if (item.Value == i)
                    {
                        result.Add(item.Key);
                    }
                }
            }

            return result;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int count = 0;
            foreach (BEReview review in Repository.GetAll())
            {
                if (review.Reviewer == reviewer)
                    count++;
            }
            return count;
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
