using RPG.Metagame.Heroes;
using UnityEngine;

namespace RPG.GameMap.Tavern
{
    [CreateAssetMenu(fileName = "TavernHeroConfig", menuName = "RPG/Heroes/TavernHeroConfig")]
    public class TavernHeroConfig : HeroConfig
    {
        [SerializeField] private TavernHeroType _type;
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;
        [SerializeField] private int _price;

        public TavernHeroType Type => _type;
        public Sprite Icon => _icon;
        public string Description => _description;
        public int Price => _price;
    }
}

