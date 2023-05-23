using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Scrollbar _bar;
    private float _statVaule = 0.01f;

    public void UpdateVaule(float vaule)
    {
        _statVaule = vaule;
        if (_statVaule > 1f)
        {
            _statVaule = 1;
            Debug.Log($"Vaule > MaxVaule in {gameObject.name}");
        }
    }
}
