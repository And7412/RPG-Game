using RPG.GameMap.Shop;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shared.SystemData
{
    [CreateAssetMenu(menuName = "RPG/VedorsDatabase", fileName = "VedorsDatabase")]
    public class VenderDataBase : ScriptableObject
    {
        [SerializeField] private List<VendorConfig> _vendors;

        public IReadOnlyList<VendorConfig> Vendors => _vendors;

        private void OnValidate()
        {
            var ids = new List<string>();
            var vendors = new List<VendorConfig>();

            foreach (var vendor in _vendors)
            {
                if (!ids.Contains(vendor.Id))
                {
                    vendors.Add(vendor);
                    ids.Add(vendor.Id);
                }
            }

            _vendors = vendors;
        }
    }
}