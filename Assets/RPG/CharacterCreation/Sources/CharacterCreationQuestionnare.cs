using RPG.Metagame.Player;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CharacterCreationQuestionnare : MonoBehaviour
    {
        [SerializeField] private CreationQuestionnareDialog _dialog;
        [SerializeField] private QuestionConfig[] _configs;
        
        public async Task<AttributeMock[]> Run()
        {
            List<AttributeMock> _attributeMocks=new List<AttributeMock>();
            foreach(var config in _configs)
            {
                var answer = await _dialog.Run(new CreationQuestionnareArgs(config));
                _attributeMocks.AddRange(answer.PlayerAttributes);
            }
            
            return _attributeMocks.ToArray();
        }
    }
}
