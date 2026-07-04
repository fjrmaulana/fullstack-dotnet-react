using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BackEnd_App.Models;

namespace BackEnd_App.Data
{
    public class AppDbContext(DbContextOptions options): Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public required DbSet<Models.Activity>  Activities { get; set; }
    }
}
