using ExcelReader.Data;
using ExcelReader.Services.Models;

namespace ExcelReader.Repository;

public class MovieRepository(AppDbContext context) : IMovieRepository
{
    private readonly AppDbContext _context = context;

    public void InsertAll(List<Movie> movies)
    {
            _context.Movies.AddRange(movies);
            _context.SaveChanges();
    }

    public IEnumerable<Movie> FetchAll()
    {
        return _context.Movies;
    }
}