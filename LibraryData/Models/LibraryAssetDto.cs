using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class LibraryAssetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public StatusDto Status { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public int NumberOfCopies { get; set; }
        public LibraryBranchDto location { get; set; }
    }
}
