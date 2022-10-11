using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.InventorySystem
{

    public class InventoriFabric : MonoBehaviour
    {
        [SerializeField] private ItemInventoryView _item;
        [SerializeField] private RectTransform _root;

        public ItemInventoryView Create(InventoryCell cell)
        {
            var item = Instantiate(_item, _root);
            _item.SetCell(cell);
            return item;
        }
    }
}
