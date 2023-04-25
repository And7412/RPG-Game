using RPG.GameMap.Shop;
using System.Linq;
using System;
using RPG.Shared.SystemData;
using System.Collections.Generic;
using RPG.Shared.UserData;

namespace RPG.GameMap.MarketSystem
{
    public class Market: ISavable<VendorsData>
    {
        private readonly Vendor[] _vendors;

        public Market(VenderDataBase dataBase)
        {
            List<Vendor> listVendors=new List<Vendor>();

            foreach(var vendorConfig in dataBase.Vendors)
            {
                var vendor = new Vendor(vendorConfig);
                listVendors.Add(vendor);
            }
            _vendors = listVendors.ToArray();
        }

        public VendorsData GetForSave()
        {
            var result = new VendorsData();
            var listVD = new List<VendorSave>();
            foreach (var vendor in _vendors)
            {
                listVD.Add(vendor.GetForSave());
            }

            result.VendorSaves = listVD.ToArray();

            return result;
        }

        public Vendor GetVendorByID(string shopId)
        {
            var result = _vendors.FirstOrDefault(x => x.Id == shopId);
            if (result!=null)
            {
                return result;
            }
            throw new ArgumentException($"not faund vender s id {shopId}");
        }

    }
}
