using Movie_Rating_Compulsory;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Xunit;
using System.Linq;
using System.Diagnostics;

namespace MovieReviewTest
{
    public class UnitTest1
    {

        private const string PATH = "../../../../ratings.json";

        [Fact]
        public void NumberOfReviews()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSONTop10(PATH);

            mr.Reviews = list;
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        List<Review> ReadJSONTop10(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path)) {
                sr.ReadLine();
                for (int i = 0; i < 10; i++) {
                    string json = sr.ReadLine();
                    json = json.Substring(0, json.Length-2);
                    reviews.Add(JsonConvert.DeserializeObject<Review>(json));
                }
            }

            return reviews;
        }

        List<Review> ReadJSON(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path))
            {
                // TODO: Optional task: do not read everything at once.
                string json = sr.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<List<Review>>(json);
            }

            return reviews;
        }

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

        #region MovieReviewers

        [Fact]
        public void MovieReviewersTest()
        {
            IMovieRating rating = new MovieRating();
            List<Review> reviews = ReadJSONTop10(PATH);

            List<int> expected = new List<int> { 1 }; // The first ten movies are all reviewed by reviewer #1.
            rating.Reviews = reviews;

            Assert.Equal(expected, rating.MovieReviewers(1488844));
            Assert.Equal(expected, rating.MovieReviewers(822109));
            Assert.Equal(expected, rating.MovieReviewers(885013));
        }

        [Fact]
        public void MovieReviewersPerfTest()
        {
            IMovieRating rating = new MovieRating();

            List<Review> reviews = ReadJSON(PATH);
            rating.Reviews = reviews;

            Stopwatch sw;
            Random r = new Random();
            for (int i = 0; i < 200; i++)
            {
                int id = r.Next(333, 2378530); // Get a random ID (because numbers in the file do not start from 1)
                sw = Stopwatch.StartNew();
                rating.MovieReviewers(id);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion
    }
}
