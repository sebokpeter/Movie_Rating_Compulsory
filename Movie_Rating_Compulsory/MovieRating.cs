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

        public List<Review> MovieMostTopRate()
        {
            var topRatedMovies = Reviews.OrderBy(r => r.Grade ==5 ).ToList();
            foreach (var movie in topRatedMovies)
            {
                Debug.WriteLine(movie.Movie);
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
            throw new NotImplementedException();
        }

        public List<int> TopMovies(int num)
        {
            throw new NotImplementedException();
        }
    }
}
