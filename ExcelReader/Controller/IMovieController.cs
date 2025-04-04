using ExcelReader.Services.Models;

namespace ExcelReader.Controller;

public interface IMovieController
{
    public void InsertAll(List<Movie> movies);
    public List<Movie> GetAllMovies();
}