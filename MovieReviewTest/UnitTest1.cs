using Movie_Rating_Compulsory;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Xunit;
using System.Diagnostics;

namespace MovieReviewTest
{
    public class UnitTest1
    {
        /// <summary>
        /// Test with top 10 data to check how the method works. 
        /// </summary>
        [Fact]
        public void AvarageRatingTestWithTop10()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSONTop10("../../../../ratings.json");

            mr.Reviews = list;

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
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSON("../../../../ratings.json");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieReviewAvg(1488844);

            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);
        }

        /// <summary>
        /// Check the grade how many times was given to the paramater movie(with top 10 data)
        /// </summary>
        [Fact]
        public void MovieReviewbyGradeCounterWithTop10()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSONTop10("../../../../ratings.json");

            mr.Reviews = list;

            double res = mr.MovieReviewByGrade(1488844, 3);
            var exp = 1;
            Assert.Equal(res, exp);

        }

        /// <summary>
        /// Check the grade how many times was given to the paramater movie(with all data)
        /// </summary>
        [Fact]
        public void MovieReviewbyGradeCounterWithAllData()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSON("../../../../ratings.json");

            mr.Reviews = list;

            double res = mr.MovieReviewByGrade(1488844,3);
            var exp = 66;
            Assert.Equal(res, exp);

        }

        /// <summary>
        /// Test with all the data to check if the method can be compiled at maximum 4 sec.
        /// </summary>
        [Fact]
        public void MovieReviewbyGradeCounterPerformanceTest()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSON("../../../../ratings.json");

            mr.Reviews = list;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.MovieReviewByGrade(1488844, 3);
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

        }

        /// <summary>
        /// Test for finding the most top rated(5) movies with top 10, and expecting back a list
        /// </summary>
        [Fact]
        public void MovieMostTopRatedWithTop10()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSONTop10("../../../../ratings.json");

            mr.Reviews = list;

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
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSONTop10("../../../../ratings.json");

            mr.Reviews = list;

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
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSON("../../../../ratings.json");

            mr.Reviews = list;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var res = mr.MovieMostTopRate();
           
            sw.Stop();

            Assert.True(sw.ElapsedMilliseconds < 4000);

        }

        [Fact]
        public void ReviewerTopCountWithTop10()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSON("../../../../ratings.json");

            mr.Reviews = list;

            List<int> res = mr.ReviewerTopCount();
            List<int> exp = new List<int> { 571 };
            Assert.Equal(res, exp);
        }

        [Fact]
        public void ReviewerTopCountPerformanceTest()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSON("../../../../ratings.json");

            mr.Reviews = list;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            mr.ReviewerTopCount();
            sw.Stop();
            Assert.True(sw.ElapsedMilliseconds < 4000);

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
        
    }
}
