using ExcelReader.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}