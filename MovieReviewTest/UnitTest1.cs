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

        [Fact]
        public void NumberOfReviews()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSONTop10("../../../../ratings.json");
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        [Fact]
        public void NumberOfReviewsPerformance()
        {
            IMovieRating mr = new MovieRating();
            mr.Reviews = ReadJSON("../../../../ratings.json");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            mr.NumberOfReviews(1);
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

        static List<Review> ReadJSON(string path)
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
