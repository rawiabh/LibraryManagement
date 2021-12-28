using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public interface IPatrons
    {

        public List<Patron> getAllPatrons();

        public Patron getPatronById(int id);

        public decimal getFeeCost(int id);


    }
}
