using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RPG.GameMap.MarketSystem
{
    public class StatPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _money;
        [SerializeField] private Scrollbar _scrolBarHelse;
        public void Initialized(int money)
        {
            _money.text = $"{money}" ;
            //while (helse < 1)
            //{
            //    helse = helse % 10;
            //}
            //_scrolBarHelse.size = helse;
        }
    }
}
