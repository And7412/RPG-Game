using UnityEngine;

namespace RPG.Quests
{
    [CreateAssetMenu(menuName = "RPG/Quests/QuestConfig", fileName = "QuestConfig")]
    public class QuestConfig : ScriptableObject
    {
        [SerializeField] private string _id;

        public string ID => _id;
    }
}

