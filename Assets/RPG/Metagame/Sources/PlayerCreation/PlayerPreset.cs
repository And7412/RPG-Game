using UnityEngine;

namespace RPG.Metagame.PlayerCreation
{
    [CreateAssetMenu(menuName = "RPG/PlayerPreset", fileName = "PlayerPreset")]
    public class PlayerPreset : ScriptableObject
    {
        [SerializeField] private string _name;
    }
}

