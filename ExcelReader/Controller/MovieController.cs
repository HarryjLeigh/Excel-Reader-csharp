using ExcelReader.Repository;
using ExcelReader.Services.Models;

namespace ExcelReader.Controller;

public class MovieController(IMovieRepository movieRepository) : IMovieController
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public void InsertAll(List<Movie> movies)
    {
        _movieRepository.InsertAll(movies);
    }

    public List<Movie> GetAllMovies()
    {
        return _movieRepository.FetchAll().ToList();
    }
}