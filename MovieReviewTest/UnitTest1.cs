using Movie_Rating_Compulsory;
using System;
using System.Collections.Generic;
using Xunit;

namespace MovieReviewTest
{
    public class UnitTest1
    {
        [Fact]
        public void NumberOfReviews()
        {
            IMovieRating mr = new MovieRating();
            List<Review> list = new List<Review>();

            mr.Reviews = list;
            int res = mr.NumberOfReviews(1);
            int exp = 10;
            Assert.Equal(res, exp);
        }
    }
}
