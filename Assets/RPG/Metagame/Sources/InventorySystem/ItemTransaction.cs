namespace RPG.Metagame.InventorySystem
{
    public class ItemTransaction
    {
        public int Money { get; }
        public string ItemId { get; }
        public int ItemCount { get; }

        public ItemTransaction(int money, string itemId, int itemCount)
        {
            Money = money;
            ItemId = itemId;
            ItemCount = itemCount;
        }
    }

    public enum ItemTransactionResult
    {
        None,
        NoMoney,
        Overweight
    }
}

