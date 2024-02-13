using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Slider hPBar;

    public void SetHUD(Unit unit)
    {
        hPBar.maxValue = unit.maxHP;
        hPBar.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hPBar.value = hp;
    }
}
