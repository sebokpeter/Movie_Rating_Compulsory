using Movie_Rating_Compulsory;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Xunit;

namespace MovieReviewTest
{
    public class UnitTest1
    {

        [Fact]
        public void NumberOfReviews()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSONTop10("../../../../ratings.json");

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
            List<Review> reviews = ReadJSONTop10("..\ratings.json");
        }

        #endregion

    }
}
