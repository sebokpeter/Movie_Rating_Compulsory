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
<<<<<<< HEAD
=======
        [Fact]
        public void NumberOfReviews()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = ReadJSON("rating.json");

            mr.Reviews = list;
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }

        List<Review> ReadJSONTop10(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path)) {
                for (int i = 0; i < 10; i++) {
                    string json = sr.ReadLine();
                    reviews.Add(JsonConvert.DeserializeObject<Review>(json));
                }
            }

            return reviews;
        }

>>>>>>> master
        List<Review> ReadJSON(string path)
        {
            List<Review> reviews = new List<Review>();

            using (StreamReader sr = new StreamReader(path))
            {
                // TODO: Optional task: do not read everything at once.
                string json = sr.ReadToEnd();
                reviews = JsonConvert.DeserializeObject<List<Review>>(json);
            }
<<<<<<< HEAD
            
=======

>>>>>>> master
            return reviews;
        }
        
    }
}
