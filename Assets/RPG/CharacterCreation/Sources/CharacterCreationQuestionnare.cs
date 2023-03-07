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
        public async Task<PlayerAttributes> Run()
        {
            
            return new PlayerAttributes(1,1,1,1,1,1,1);
        }
    }
}
