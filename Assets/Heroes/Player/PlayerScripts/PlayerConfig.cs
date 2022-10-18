using RPG.Heroes;
using RPG.InventorySystem;
using UnityEngine;

namespace RPG.PlayerSystem
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "RPG/Heroes/PlayerConfig", order = 0)]
    public class PlayerConfig : HeroConfig
    {
        [SerializeField] private Inventory _inventory;

        public Inventory Inventory => _inventory;
    }
}

