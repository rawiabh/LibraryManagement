using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class HoldDto
    {

        public int Id { get; set; }
        public DateTime HoldPlaced { get; set; }
        public DateTime UpdatedOn { get; set; }
        public LibraryAssetDto LibraryAsset { get; set; }
        public LibraryCardDto LibraryCard { get; set; }
    }
}
