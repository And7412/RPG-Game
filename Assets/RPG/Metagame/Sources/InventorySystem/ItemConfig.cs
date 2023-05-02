using RPG.Shared;
using UnityEngine;
namespace RPG.Metagame.InventorySystem
{
    public abstract class ItemConfig : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private ItemRarity itemRarity = ItemRarity.Simple;
        public abstract InventorySlotType InventorySlot { get; }
        private string _idResult;

        private void OnValidate()
        {
            _idResult = IdCreator.GetItemId(InventorySlot, _id);
        }

        public int GetCapacity()
        {
            switch(InventorySlot)
            {
                default:
                    return 1;
                case InventorySlotType.Misc:
                    return 128;
            }
            
        }

        public Sprite Sprite => _sprite;
        public string Id => _idResult;
        public ItemRarity ItemRarity => itemRarity; 
    }
}
