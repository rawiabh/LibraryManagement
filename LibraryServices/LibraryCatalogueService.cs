using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Models;

namespace LibraryServices
{
    public class LibraryCatalogueService : IAssets
    {

        private LibraryContexts _db;

        public LibraryCatalogueService(LibraryContexts db)
        {
            _db = db;
        }

        public List<LibraryAssetDto> getAllAssets()
        {
            return _db.LibraryAssetDtos.ToList();

        }

        public LibraryAssetDto getAssetById(int assetId)
        {

            return _db.LibraryAssetDtos.FirstOrDefault(x=>x.Id == assetId);
        }

        public CheckoutHistoryDto getCheckoutHistoryOfaAsset(int assetId)
        {
            return _db.CheckoutHistoryDto.FirstOrDefault(x => x.LibraryAsset.Id == assetId);
        }

        public HoldDto getHoldsOnAsset(int assetId)
        {
            return _db.HoldDto.FirstOrDefault(x => x.LibraryAsset.Id == assetId);

        }

        public bool isCheckedout(int assetId)
        {
           return  _db.CheckoutHistoryDto.Any(x => x.Id == assetId);
               
        }

        public bool isItemLost(int assetId)
        {
            throw new NotImplementedException();

        }

        public bool isOnHold(int assetId)
        {
            return _db.HoldDto.Any(x => x.Id == assetId);
        }

       public void AddAsset(LibraryAssetDto asset)
        {
            _db.Add(asset);
            _db.SaveChanges();
        }

        public LibraryBranchDto getLocation(int assetId)
        {
            return _db.LibraryBranchDtos.FirstOrDefault(x => x.Id == assetId);
        }
    }
}
