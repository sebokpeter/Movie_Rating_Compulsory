using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Rating_Compulsory
{
    public class MovieRating : IMovieRating
    {
        public List<Review> Reviews { get; set; }

        public double AvgOfReviewer(int rID)
        {
            double avg = Reviews.Where(x => x.Reviewer == rID).Average(x => x.Grade);
            return avg;
        }

        public int GradeCountByID(int rID, int grade)
        {
            int count = Reviews.Where(x => x.Reviewer == rID && x.Grade == grade).Count();
            return count;
        }

        public List<int> MovieMostTopRate()
        {
            throw new NotImplementedException();
        }

        public double MovieReviewAvg(int mID)
        {
            throw new NotImplementedException();
        }

        public int MovieReviewByGrade(int mID, int grade)
        {
            throw new NotImplementedException();
        }

        public int MovieReviewerCount(int mID)
        {
            int count = Reviews.Where(x => x.Movie == mID).Count();
            return count;
        }

        public List<int> MovieReviewers(int mID)
        {
            throw new NotImplementedException();
        }

        public int NumberOfReviews(int rID)
        {
            int count = Reviews.Where(x => x.Reviewer == rID).Count();
            return count;
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
            throw new NotImplementedException();
        }
    }
}
