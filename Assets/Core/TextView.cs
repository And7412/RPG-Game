using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void SetText(string value)
    {
        _text.text = value;
    }
    public void SetText(int value)
    {
        _text.text = value.ToString();
    }
    public void SetText(float value)
    {
        _text.text = value.ToString();
    }
}
