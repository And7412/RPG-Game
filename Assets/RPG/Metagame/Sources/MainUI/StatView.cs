using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatView : MonoBehaviour
{
    [SerializeField] private TMP_Text _value; 

    public void ValueSet(int value)
    {
        _value.SetText(value.ToString());
    }
}
