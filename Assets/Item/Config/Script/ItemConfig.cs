using UnityEngine;
namespace RPG.Item.Config
{
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] protected TypeItem Type;
        [SerializeField] protected ReceiptType ReceiptType;
    }
}
