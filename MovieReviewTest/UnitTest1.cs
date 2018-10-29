using Movie_Rating_Compulsory;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Xunit;
using System.Diagnostics;
using System.Linq;

namespace MovieReviewTest
{
    public class UnitTest1
    {
        private const string PATH = "../../../../ratings.json";

        #region NumberOfReviewsTest

        [Fact]
        public void NumberOfReviewsTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSONTop10(PATH);
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void NumberOfReviewsPerformanceTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSON(PATH);
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            mr.NumberOfReviews(rnd.Next(1, 999));
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region AvgOfReviewerTest

        [Fact]
        public void AvgOfReviewerTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSONTop10(PATH);
            double res = mr.AvgOfReviewer(1);
            double exp = 3.6;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void AvgOfReviewerPerformanceTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSON(PATH);
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            double res = mr.AvgOfReviewer(rnd.Next(1, 999));
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region GradeCountByIDTest

        [Fact]
        public void GradeCountByIDTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSONTop10(PATH);
            int res = mr.GradeCountByID(1, 4);
            int exp = 4;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void GradeCountByIDPerformanceTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSON(PATH);
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.GradeCountByID(rnd.Next(1, 999), rnd.Next(1, 5));
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region MovieReviewerCountTest

        [Fact]
        public void MovieReviewerCountTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSONTop10(PATH);
            int res = mr.MovieReviewerCount(1488844);
            int exp = 1;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void MovieReviewerCountPerformanceTest()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSON(PATH);
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.MovieReviewerCount(1488844);
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region TopMoveTests

        [Fact]
        public void TopMovieTest()
        {
            IMovieRating rating = new MovieRating();
            List<Review> reviews = ReadJSONTop10(PATH);

            rating.Reviews = reviews;

            rating.TopMovies(10);
            
        }

        #endregion

        #region ReviewerMovies

        [Fact]
        public void ReviewerMoviesTest()
        {
            IMovieRating rating = new MovieRating();
            List<Review> reviews = ReadJSONTop10(PATH);

            // The first ten movies are all reviewed by reviewer #1.
            List<int> expected = reviews.OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date).Select(m => m.Movie).ToList();
 
            rating.Reviews = reviews;

            Assert.Equal(expected, rating.RevieverMovies(1));
        }

        [Fact]
        public void ReviewerMoviePerfTest()
        {
            IMovieRating rating = new MovieRating();

            List<Review> reviews = ReadJSON(PATH);
            rating.Reviews = reviews;

            Stopwatch sw;

            for (int i = 0; i < 100; i++)
            {
                sw = Stopwatch.StartNew();
                rating.RevieverMovies(i);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

        List<Review> ReadJSONTop10(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path)) {
                sr.ReadLine();
                for (int i = 0; i < 10; i++) {
                    string json = sr.ReadLine();
                    json = json.Substring(0, json.Length - 2);
                    reviews.Add(JsonConvert.DeserializeObject<Review>(json));
                }
            }

            return reviews;
        }

        static List<Review> ReadJSON(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path)) {
                // TODO: Optional task: do not read everything at once.
                string json = sr.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<List<Review>>(json);
            }

            return reviews;
        }

    }
}
