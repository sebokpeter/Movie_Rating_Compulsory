 using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rating_Compulsory
{
    public interface IMovieRating
    {
        //List<Review> Reviews { get; set; }
        HashSet<Review> Reviews { get; set; }

        /// <summary>
        /// Returns the number of reviews made by the reviewer.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <returns>The number of reviews made by the reviewer with the of rID</returns>
        int NumberOfReviews(int rID);

        /// <summary>
        /// Returns the average grade that the reviewer had given.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <returns>The average grade given by the reviewer with rID.</returns>
        double AvgOfReviewer(int rID);

        /// <summary>
        /// Returns the number of times the reviewer had given a specific grade.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <param name="grade">Grade</param>
        /// <returns>The number of times the reviewer with rID given a specific date.</returns>
        int GradeCountByID(int rID, int grade);

        /// <summary>
        /// Returns the number of reviewers that reviwed the movie.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <returns>The number of reviewers that reviewed the movie with the id of mID.</returns>
        int MovieReviewerCount(int mID);

        /// <summary>
        /// Returns the average of ratings a movie had received.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <returns>The average ratings of the movie with the id of mID.</returns>
        double MovieReviewAvg(int mID);

        /// <summary>
        /// Returns the number of when a given movie received a specific grade.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <param name="grade">Grade</param>
        /// <returns>The number of times the movie with the id mID recieved the given grade.</returns>
        int MovieReviewByGrade(int mID, int grade);

        /// <summary>
        /// Returns a list of movies with the highest number of top ratings.
        /// </summary>
        /// <returns>The list of movies with the highest ratings.</returns>
        List<int> MovieMostTopRate();

        /// <summary>
        /// Returns the reviewer(s) with the most reviews.
        /// </summary>
        /// <returns>The reviewer(s) with the most reviews.</returns>
        List<int> ReviewerTopCount();

        /// <summary>
        /// Returns the given number of top movies ordered by its average rating.
        /// </summary>
        /// <param name="num">Number of movies</param>
        /// <returns>The given number of top movies, ordered by their average rating.</returns>
        List<int> TopMovies(int num);

        /// <summary>
        /// Returns the list of movies reviewed by a specific reviewer.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <returns>The list of movies reviewed my the reviewer with the id of rID.</returns>
        List<int> RevieverMovies(int rID);

        /// <summary>
        /// Returns the list of reviewers that revieved a specific movie.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <returns>The list of reviwers who reviewed the movie with the id of mID.</returns>
        List<int> MovieReviewers(int mID);
    }
}
