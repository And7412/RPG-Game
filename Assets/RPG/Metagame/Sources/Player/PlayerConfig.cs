using RPG.Metagame.Heroes;
using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.Metagame.Heroes.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "RPG/Heroes/PlayerConfig", order = 0)]
    public class PlayerConfig : HeroConfig
    {
        [SerializeField] private Inventory _inventory;

        public Inventory Inventory => _inventory;
    }
}

