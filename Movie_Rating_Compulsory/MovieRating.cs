using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Rating_Compulsory
{
    public class MovieRating : IMovieRating
    {
        //public List<Review> Reviews { get; set; }

        public HashSet<Review> Reviews { get; set; }

        public double AvgOfReviewer(int rID)
        {
            throw new NotImplementedException();
        }

        public int GradeCountByID(int rID, int grade)
        {
            throw new NotImplementedException();
        }

        public List<int> MovieMostTopRate()
        {
            List<int> topRatedMovies  = new List<int>();

            var topRatedMoviesGrade = Reviews.Where(r => r.Grade == 5);

            foreach (var movie in topRatedMoviesGrade)
            {
                if(!topRatedMovies.Contains(movie.Movie))
                {
                    topRatedMovies.Add(movie.Movie);
                }
            }
            return topRatedMovies;
        }

        public double MovieReviewAvg(int mID)
        {
            int sumOfGrades = 0;
            int numOfReviewer = 0;

            var movieList = Reviews.Where(review => mID == review.Movie);

            foreach (var movie in movieList)
            {
                sumOfGrades += movie.Grade;
                numOfReviewer++;
            }
            double averageRate = sumOfGrades / numOfReviewer;
            return averageRate;
               
        }

        public int MovieReviewByGrade(int mID, int grade)
        {
            var gradeCounter = 0;

            var movieList = Reviews.Where(review => mID == review.Movie && review.Grade == grade);
            
            foreach (var movieByGrade in movieList)
            {
                gradeCounter++;
            }

            return gradeCounter;
        }

        public int MovieReviewCount(int mID)
        {
            throw new NotImplementedException();
        }

        public int NumberOfReviews(int rID)
        {
            throw new NotImplementedException();
        }

        public List<int> RevieverMovies(int rID)
        {
            List<int> reviewerMovies = Reviews.Where(m => m.Reviewer == rID)
                .OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date)
                .Select(m => m.Movie).ToList();

            return reviewerMovies;
        }

        public List<int> ReviewerTopCount()
        {
            throw new NotImplementedException();
        }

        public List<int> TopMovies(int num)
        {
            // Dictionary<int, double> averages = new Dictionary<int, double>();

            //ConcurrentDictionary<int, double> averages = new ConcurrentDictionary<int, double>();

            //Parallel.ForEach(Reviews, (item) =>
            //{
            //    if (!averages.ContainsKey(item.Movie))
            //    {
            //        double avg = MovieReviewAvg(item.Movie);

            //        bool success = averages.TryAdd(item.Movie, avg);
            //        while (success)
            //        {
            //            success = averages.TryAdd(item.Movie, avg);
            //        }
            //    }
            //});

            

            //IQueryable<A> res = from r in Reviews.AsQueryable() group r by r.Movie into result select new A{mov = result.Key, avg = result.Average(m => m.Grade) };


            var res = Reviews.GroupBy(r => r.Movie).Select(result => new { mov = result.Key, avg = result.Average(m => m.Grade) });

            var ordered = res.OrderByDescending(m => m.avg).Take(num).Select(m => m.mov).ToList();
            //string str = res.ToString();
            return ordered;
        }

        public List<int> MovieReviewers(int mID)
        {
            List<int> reviewers = Reviews.Where(r => r.Movie == mID)
                .OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date)
                .Select(m => m.Reviewer).ToList();
            return reviewers;
        }
    }
}
