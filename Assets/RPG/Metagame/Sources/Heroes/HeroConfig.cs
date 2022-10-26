using UnityEngine;

namespace RPG.Metagame.Heroes
{
    public class HeroConfig : ScriptableObject
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _maxStamina = 100;
        public int MaxHealth => _maxHealth;
        public int MaxStamina => _maxStamina;
    }
}

