using RPG.Metagame.Player;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
//ДЗ
namespace RPG.CharacterCreation
{
    public class CharacterCreationQuestionnare : MonoBehaviour
    {
        [SerializeField] private CreationQuestionnareDialog _dialog;
        [SerializeField] private QuestionConfig[] _configs;
        public async Task<PlayerAttributes> Run()
        {
            foreach(var config in _configs)
            {
                _dialog.Open(new CreationQuestionnareArgs(config));
                
            }
            
            return new PlayerAttributes(1,1,1,1,1,1,1);
        }
    }
}
