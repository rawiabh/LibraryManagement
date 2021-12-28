using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;

namespace LibraryServices
{
    public class PatronsManagementService : IPatrons
    {

        public LibraryContexts libraryContexts;

        public PatronsManagementService(LibraryContexts libraryContexts)
        {
            this.libraryContexts = libraryContexts;
        }

       public List<Patron> getAllPatrons()
        {

           return  libraryContexts.Patrons.ToList();
        }

       public decimal getFeeCost(int id)
        {
           return  libraryContexts.Patrons.FirstOrDefault(x => x.Id == id).OverdueFees;
        }

       public  Patron getPatronById(int id)
        {

           return  libraryContexts.Patrons.FirstOrDefault(x => x.Id == id);
        }
    }
}
