using UnityEngine;
using System.Collections;

public interface IPlayerTrade
{

    
    void Increase(int value);
    bool TryDecrease(int value);
}
