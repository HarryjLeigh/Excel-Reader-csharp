using ExcelReader.Services.Models;

namespace ExcelReader.Repository;

public interface IMovieRepository
{
    void InsertAll(List<Movie> movies);
    IEnumerable<Movie> FetchAll();
}