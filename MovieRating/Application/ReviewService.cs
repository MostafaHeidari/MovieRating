using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            
            BEReview[] allReviews = Repository.GetAll();
            if (allReviews.Any(review => review.Reviewer == reviewer))
                return allReviews.Where(review => review.Reviewer == reviewer)
                    .Select(reviewer => reviewer.Grade)
                    .Average();
            throw new ArgumentException(message: "Re is not found");

        }


        public decimal GetAverageRateOfMovie(int movie, decimal expectedAverage)
        {
            BEReview[] fakeRepo = Repository.GetAll();

            int countMovie = 0;
            decimal countGrade = 0;

            foreach (var item in fakeRepo)
            {
                if (movie == item.Movie)
                {
                    countMovie++;
                    countGrade += item.Grade;
                }
            }

            if (countMovie == 0)
            {
                return 0;
            }
            return countGrade/countMovie;
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
            BEReview[] fakeRepo = Repository.GetAll();

            var counts = new Dictionary<int, int>();

            foreach (var item in fakeRepo)
            {
                int count;
                counts.TryGetValue(item.Movie, out count);
                count++;
                //Automatically replaces the entry if it exists;
                //no need to use 'Contains'
                counts[item.Movie] = count;
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

        public int GetNumberOfRates(int movie, int grade, int expectedNumberOfCertainGrades)
        {
            BEReview[] fakeRepo = Repository.GetAll();

            int counts = 0;

            foreach (var item in fakeRepo)
            {
                if (movie == item.Movie && grade == item.Grade)
                {
                    counts++;
                }
            }

            return counts;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            BEReview[] fakeRepo = Repository.GetAll();

            int counts = 0;

            foreach (var item in fakeRepo)
            {
                if (reviewer == item.Reviewer && rate == item.Grade)
                {
                    counts++;
                }
            }

            return counts;
        }

        public int GetNumberOfReviews(int movie)
        {
            BEReview[] allReviews = Repository.GetAll();
            if (allReviews.Any(review => review.Movie == movie))
                return allReviews.Count(review => review.Movie == movie);
        
            throw new ArgumentException("Movie does not exist");
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
