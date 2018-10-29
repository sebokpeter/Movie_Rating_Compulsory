 using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Rating_Compulsory
{
    public interface IMovieRating
    {
        /// <summary>
        /// Returns the number of reviews made by the reviewer.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <returns></returns>
        int NumberOfReviews(int rID);

        /// <summary>
        /// Returns the average rate that the reviewer had given.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <returns></returns>
        double AvgOfReviewer(int rID);

        /// <summary>
        /// Returns the number of times the reviewer had given a specific grade.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <param name="grade">Grade</param>
        /// <returns></returns>
        int GradeCountByID(int rID, int grade);

        /// <summary>
        /// Returns the number of reviewers that reviwed the movie.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <returns></returns>
        int MovieReviewCount(int mID);

        /// <summary>
        /// Returns the average of ratings a movie had received.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <returns></returns>
        double MovieReviewAvg(int mID);

        /// <summary>
        /// Returns the number of when a given movie received a specific grade.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <param name="grade">Grade</param>
        /// <returns></returns>
        int MovieReviewByGrade(int mID, int grade);

        /// <summary>
        /// Returns a list of movies with the highest number of top ratings.
        /// </summary>
        /// <returns></returns>
        List<int> MovieMostTopRate();

        /// <summary>
        /// Returns the reviewer(s) with thw most reviews.
        /// </summary>
        /// <returns></returns>
        List<int> ReviewerTopCount();

        /// <summary>
        /// Returns the given number of top movies ordered by its average rating.
        /// </summary>
        /// <param name="num">Number of movies</param>
        /// <returns></returns>
        List<int> TopMovies(int num);

        /// <summary>
        /// Returns the list of movies reviewed by a specific reviewer.
        /// </summary>
        /// <param name="rID">Reviewer ID</param>
        /// <returns></returns>
        List<int> RevieverMovies(int rID);

        /// <summary>
        /// Returns the list of reviewers that revieved a specific movie.
        /// </summary>
        /// <param name="mID">Movie ID</param>
        /// <returns></returns>
        List<int> MovieReviewers(int mID);
    }
}
