using ExcelReader;
using ExcelReader.Controller;
using ExcelReader.Repository;
using ExcelReader.Services;
using ExcelReader.Services.Models;
using ExcelReader.Util;
using Microsoft.Extensions.DependencyInjection;

string path = @"Add file path to MovieData.xlsx verbatim";

Startup startup = new Startup();
startup.Configure();
using var scope = startup._serviceProvider.CreateScope();

var movieRepository = startup._serviceProvider.GetService<IMovieRepository>();
FileService fileService = new FileService(path);
MovieController movieController = new MovieController(movieRepository);

var movieData = fileService.ReadExcelFile();
movieController.InsertAll(movieData);
List<Movie> fetchedMovies = movieController.GetAllMovies();
TableVisualisation.ShowData(fetchedMovies);