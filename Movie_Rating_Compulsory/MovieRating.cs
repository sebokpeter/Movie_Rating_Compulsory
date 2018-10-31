using System.Collections.Generic;
using System.Linq;

namespace Movie_Rating_Compulsory
{
    public class MovieRating : IMovieRating
    {
        //public List<Review> Reviews { get; set; }

        public HashSet<Review> Reviews { get; set; }

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
            var topRatedMoviesGrade = Reviews.Where(r => r.Grade == 5).Select(r => r.Movie).ToList();
            
            return topRatedMoviesGrade;
        }

        public double MovieReviewAvg(int mID)
        {
            var averageRate = Reviews.Where(review => mID == review.Movie).Average(r => r.Grade);
            
            return averageRate;
               
        }

        public int MovieReviewByGrade(int mID, int grade)
        {
            var gradeCounter = Reviews.Where(review => mID == review.Movie && review.Grade == grade).Count();
            
            return gradeCounter;
        }

        public int MovieReviewerCount(int mID)
        {
            int count = Reviews.Where(x => x.Movie == mID).Count();
            return count;
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
            var reviewerCounted = Reviews.GroupBy(r => r.Reviewer).Select(g => g.Count()).ToList();
            List<int> list = new List<int>();
            int max = -1;
            for (int i = 0; i < reviewerCounted.Count(); i++)
            {
                if (reviewerCounted[i] == max)
                {
                    list.Add(i + 1);
                }

                if (reviewerCounted[i] > max)
                {
                    list.Clear();
                    max = reviewerCounted[i];
                    list.Add(i + 1);
                }
            }
            return list;
        }

        public List<int> TopMovies(int num)
        {
            var res = Reviews.AsParallel().GroupBy(r => r.Movie).Select(result => new { mov = result.Key, avg = result.Average(m => m.Grade) });

            var ordered = res.OrderByDescending(m => m.avg).Take(num).Select(m => m.mov).ToList();
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
