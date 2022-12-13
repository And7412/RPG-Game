using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace RPG.GameMap.Shop
{
    public class StatPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        public void Initialized(int x)
        {
            _money.text = $"{x}" ;
        }
    }
}
