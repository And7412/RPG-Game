using UnityEngine;

namespace RPG.Item
{
    public abstract class ItemConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Rarity _rarity = Rarity.Simple;
        public abstract InventorySlot InventorySlot { get; }

        public int GetCapacity()
        {
            switch(InventorySlot)
            {
                default:
                    return 1;
                case InventorySlot.Misc:
                    return 128;
            }
            
        }

        public string Id => _id;
        public Rarity Rarity => _rarity; 
    }
}
