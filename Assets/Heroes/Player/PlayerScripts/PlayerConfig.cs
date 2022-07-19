using UnityEngine;

namespace RPG.PlayerSystem
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "RPG/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private int _maxHealth = 100;
        [SerializeField] private int _maxStamina = 100;

        public int MaxHealth => _maxHealth;
        public int MaxStamina => _maxStamina;
    }
}

