using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RPG.Shared.UserData.PlayerSave;

namespace RPG.Shared.SystemData
{
    [CreateAssetMenu(menuName = "RPG/QuestsDatabase", fileName = "QuestDatabase")]
    public class QuestDataBase : ScriptableObject
    {
        [SerializeField] private List<Quest> _quests;

        public List<Quest> Quests => _quests;
        private void OnValidate()
        {
            var ids = new List<string>();
            var quests = new List<Quest>();

            foreach (var quest in _quests)
            {
                if (!ids.Contains(quest.Id))
                {
                    quests.Add(quest);
                    ids.Add(quest.Id);
                }
            }

            _quests = quests;
        }
    }
}
