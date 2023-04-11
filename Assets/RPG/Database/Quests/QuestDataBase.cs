using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Quests
{
    [CreateAssetMenu(menuName = "RPG/QuestsDatabase", fileName = "QuestDatabase")]
    public class QuestDataBase : ScriptableObject
    {
        [SerializeField] private List<QuestConfig> _quests;

        public List<QuestConfig> Quests => _quests;
        private void OnValidate()
        {
            var ids = new List<string>();
            var quests = new List<QuestConfig>();

            foreach (var quest in _quests)
            {
                if (!ids.Contains(quest.ID))
                {
                    quests.Add(quest);
                    ids.Add(quest.ID);
                }
            }

            _quests = quests;
        }
    }
}
