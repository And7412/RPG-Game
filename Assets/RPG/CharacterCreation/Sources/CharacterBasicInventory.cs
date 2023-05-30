using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CharacterBasicInventory : MonoBehaviour
    {
        [SerializeField] private Inventory _testInventory;

        public Inventory GetResultInventory()
        {
            return _testInventory;
        }
    }
}

