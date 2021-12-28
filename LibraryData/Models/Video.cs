using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Models
{
    public class Video : LibraryAssetDto
    {

        public int Id { get; set; }
        public string duree { get; set; }

        public string director { get; set; }
    }
}
