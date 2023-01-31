using RPG.Metagame.InventorySystem;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shared.SystemData
{
    [CreateAssetMenu(menuName = "RPG/ItemsDatabase", fileName = "ItemsDatabase")]
    public class ItemsDatabase : ScriptableObject
    {
        [SerializeField] private List<ItemConfig> _items;

        private void OnValidate()
        {
            var ids = new List<string>();
            var items = new List<ItemConfig>();

            foreach (var item in _items)
            {
                if (!ids.Contains(item.Id))
                {
                    items.Add(item);
                    ids.Add(item.Id);
                }
            }

            _items = items;
        }
    }
}

