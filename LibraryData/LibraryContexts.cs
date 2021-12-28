using System;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryData
{
    public class LibraryContexts : DbContext
    {

        public LibraryContexts(DbContextOptions options) : base(options) { }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<LibraryAssetDto> LibraryAssetDto { get; set; }
        public DbSet<Book> Book { get; set; }

        public DbSet<Video> Video { get; set; }
        public DbSet<BranchHour> BranchHours { get; set; }

        public DbSet<CheckoutHistoryDto> CheckoutHistoryDto { get; set; }


        public DbSet<HoldDto> HoldDto { get; set; }


        public DbSet<LibraryAssetDto> LibraryAssetDtos { get; set; }


        public DbSet<LibraryBranchDto> LibraryBranchDtos { get; set; }


        public DbSet<LibraryCardDto> LibraryCardDto { get; set; }
        public DbSet<StatusDto> StatusDtos { get; set; }

        public DbSet<TagDto> TagDtos { get; set; }

        public DbSet<Video> Videos { get; set; }







    }
}
