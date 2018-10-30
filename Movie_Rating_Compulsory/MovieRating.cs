using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Movie_Rating_Compulsory
{
    public class MovieRating : IMovieRating
    {
        public List<Review> Reviews { get; set; }

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

        public List<int> MovieReviewers(int mID)
        {
            throw new NotImplementedException();
        }

        public int NumberOfReviews(int rID)
        {
            throw new NotImplementedException();
        }

        public List<int> RevieverMovies(int rID)
        {
            throw new NotImplementedException();
        }

        public List<int> ReviewerTopCount()
        {
            List<int> ReviewerWithMostReviews = new List<int>();
            int count = Reviews.OrderByDescending(r => r.Reviewer).Count();
            for
            
        }

        public List<int> TopMovies(int num)
        {
            throw new NotImplementedException();
        }
    }
}
