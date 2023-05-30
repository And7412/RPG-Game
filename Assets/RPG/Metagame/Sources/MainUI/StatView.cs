using TMPro;
using UnityEngine;

namespace RPG.Metagame.MainUI
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value; 

        public void SetValue(int value)
        {
            _value.SetText(value.ToString());
        }
    }
}

