using RPG.Metagame.InventorySystem;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    [SerializeField] private List<ItemConfig> Confids;
    private List<ItemConfig> _confids;
    private void OnValidate()
    {
        foreach(ItemConfig config in Confids)
        {
            if (!_confids.Any(x => x.Id ==config.Id))
            {
                _confids.Add(config);
            }
        }
    }
}
