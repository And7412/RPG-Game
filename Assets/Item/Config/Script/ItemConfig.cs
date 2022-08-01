using UnityEngine;

namespace RPG.Item
{
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        public virtual InventorySlot InventorySlot { get; }

        public string Id => _id;
    }
}
