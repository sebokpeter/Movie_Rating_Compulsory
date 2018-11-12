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

        private readonly HashSet<Review> firstTen = new HashSet<Review>();
        private readonly HashSet<Review> allReviews = new HashSet<Review>();

        public UnitTest1()
        {
            firstTen = ReadJSONTop10(PATH).ToHashSet();
            allReviews = ReadJSON(PATH).ToHashSet();
        }

        #region ReadFile
        List<Review> ReadJSONTop10(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    string json = sr.ReadLine();
                    json = json.Substring(0, json.Length - 2);
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


        /// <summary>
        /// Test with top 10 data to check how the method works. 
        /// </summary>
        [Fact]
        public void AvarageRatingTestWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                // List<Review> list = ReadJSONTop10(PATH);

                Reviews = firstTen
            };

            double  res = mr.MovieReviewAvg(1488844);
            var exp = 3;
            Assert.Equal(res, exp);

        }
        /// <summary>
        /// Test with all the data to check if the method can be compiled at maximum 4 sec.
        /// </summary>
        [Fact]
        public void AvarageRatingPerformanceTest()
        {

            IMovieRating mr = new MovieRating
            {
                Reviews = firstTen
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieReviewAvg(1488844);

            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #endregion

        #region MovieReviewByGrade
        /// <summary>
        /// Check the grade how many times was given to the paramater movie(with top 10 data)
        /// </summary>
        [Fact]
        public void MovieReviewbyGradeCounterWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = firstTen
            };

            double res = mr.MovieReviewByGrade(1488844, 3);
            var exp = 1;
            Assert.Equal(res, exp);

        }

        /// <summary>
        /// Check the grade how many times was given to the paramater movie(with all data)
        /// </summary>
        //[Fact]
        public void MovieReviewbyGradeCounterWithAllData()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };

            double res = mr.MovieReviewByGrade(1488844,3);
            var exp = 19;
            Assert.Equal(res, exp);

        }

        /// <summary>
        /// Test with all the data to check if the method can be compiled at maximum 4 sec.
        /// </summary>
        [Fact]
        public void MovieReviewbyGradeCounterPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSON(PATH);

                Reviews = allReviews
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieReviewByGrade(1488844, 3);
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region MovieMostTopRate
        /// <summary>
        /// Test for finding the most top rated(5) movies with top 10, and expecting back a list
        /// </summary>
        [Fact]
        public void MovieMostTopRatedWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSONTop10(PATH);

                Reviews = firstTen
            };

            var res = mr.MovieMostTopRate();
            List<int> exp = new List<int>() {822109};

            Assert.Equal(res, exp);

        }

        /// <summary>
        /// Test for findig the mos top rated(5) movies with top 10, and expecting back a number which is the number of movies added to the list
        /// </summary>
        [Fact]
        public void MovieMostTopRatedWithTop10Count()
        {
            IMovieRating mr = new MovieRating
            {
                //List<Review> list = ReadJSONTop10(PATH);

                Reviews = firstTen
            };

            var res = mr.MovieMostTopRate().Count;
            var exp = 1;

            Assert.Equal(res, exp);

        }
        /// <summary>
        /// Test for findig the mos top rated(5) movies with all data, check if it can be compiled at maximum 4 sec
        /// </summary>
        [Fact]
        public void MovieMostTopRatedPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                // List<Review> list = ReadJSON(PATH);

                Reviews = firstTen
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieMostTopRate();
           
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region ReviewerTopCount
        //[Fact]
        public void ReviewerTopCountWithTop10()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };

            List<int> res = mr.ReviewerTopCount();
            List<int> exp = new List<int> { 571 };
            Assert.Equal(res, exp);
        }

        [Fact]
        public void ReviewerTopCountPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.ReviewerTopCount();
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }
        #endregion

        #region NumberOfReviewsTest

        [Fact]
        public void NumberOfReviewsTest()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = firstTen
            };
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void NumberOfReviewsPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };
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
            IMovieRating mr = new MovieRating
            {
                Reviews = firstTen
            };
            double res = mr.AvgOfReviewer(1);
            double exp = 3.6;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void AvgOfReviewerPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };
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
            IMovieRating mr = new MovieRating
            {
                Reviews = firstTen
            };
            int res = mr.GradeCountByID(1, 4);
            int exp = 4;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void GradeCountByIDPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };
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
            IMovieRating mr = new MovieRating
            {
                Reviews = firstTen
            };
            int res = mr.MovieReviewerCount(1488844);
            int exp = 1;

            Assert.Equal(res, exp);
        }

        [Fact]
        public void MovieReviewerCountPerformanceTest()
        {
            IMovieRating mr = new MovieRating
            {
                Reviews = allReviews
            };
            Random rnd = new Random();
            Stopwatch sw = Stopwatch.StartNew();
            int res = mr.MovieReviewerCount(1488844);
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);
        }
        #region TopMovieTests

        [Fact]
        public void TopMovieTest()
        {
        IMovieRating rating = new MovieRating
        {
            // List<Review> reviews = ReadJSONTop10(PATH);
            Reviews = firstTen
        };

        int grade = 5;
            foreach (int item in rating.TopMovies(10))
            {
                Review review = firstTen.FirstOrDefault(r => r.Movie == item);
                Assert.True(grade >= review.Grade); // Ensure that the ratings are in the correct order
                grade = review.Grade;
            }
        }
        #endregion

        [Fact]
        public void TopMoviePerfTest()
        {
            IMovieRating rating = new MovieRating
            {
                //List<Review> reviews = ReadJSON(PATH);

                Reviews = allReviews
            };

            Stopwatch sw;

            for (int i = 0; i < 1; i++)
            {
                sw = Stopwatch.StartNew();
                rating.TopMovies(10);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

        #region ReviewerMovies

        [Fact]
        public void ReviewerMoviesTest()
        {
            IMovieRating rating = new MovieRating();
           // List<Review> reviews = ReadJSONTop10(PATH);

            // The first ten movies are all reviewed by reviewer #1.
            List<int> expected = firstTen.OrderByDescending(m => m.Grade).ThenByDescending(m => m.Date).Select(m => m.Movie).ToList();

            rating.Reviews = firstTen;

            Assert.Equal(expected, rating.RevieverMovies(1));
        }

        [Fact]
        public void ReviewerMoviePerfTest()
        {
        IMovieRating rating = new MovieRating
        {

            //List<Review> reviews = ReadJSON(PATH);
            Reviews = allReviews
        };

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
            //List<Review> reviews = ReadJSONTop10(PATH);

            List<int> expected = new List<int> { 1 }; // The first ten movies are all reviewed by reviewer #1.
            rating.Reviews = firstTen;

            Assert.Equal(expected, rating.MovieReviewers(1488844));
            Assert.Equal(expected, rating.MovieReviewers(822109));
            Assert.Equal(expected, rating.MovieReviewers(885013));
        }

        [Fact]
        public void MovieReviewersPerfTest()
        {
            IMovieRating rating = new MovieRating
            {
                //List<Review> reviews = ReadJSON(PATH);
                Reviews = allReviews
            };

            int[] ids = allReviews.Select(r => r.Movie).Take(200).ToArray(); // Select a bunch of movie ids

            Stopwatch sw;
            for (int i = 0; i < 200; i++)
            {
                sw = Stopwatch.StartNew();
                rating.MovieReviewers(ids[i]);
                sw.Stop();
                Assert.True(sw.ElapsedMilliseconds <= 4000);
            }
        }

        #endregion

    }
}
