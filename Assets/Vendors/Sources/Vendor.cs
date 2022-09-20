using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RPG.Vendors
{
    public class Vendor : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {

        }
    }

}
