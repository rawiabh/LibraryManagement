using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData.Models;

namespace LibraryData
{
    public interface IAssets
    {

        public List<LibraryAssetDto> getAllAssets();
        public LibraryAssetDto getAssetById(int assetId);
        public CheckoutHistoryDto getCheckoutHistoryOfaAsset(int assetId);
        public HoldDto getHoldsOnAsset(int assetId);
        public bool isCheckedout(int assetId);
        public bool isOnHold(int assetId);
        public bool isItemLost(int assetId);

        public LibraryBranchDto getLocation(int assetId);

        public void AddAsset(LibraryAssetDto asset);
    }
}
