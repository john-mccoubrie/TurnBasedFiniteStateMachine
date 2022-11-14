using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    //BattleHUD sets up texts, HP, and sliders
    public Text nameText;
    public Text levelText;
    public Text maxHPText;
    public Text currentHPText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        maxHPText.text = unit.maxHP.ToString();
        currentHPText.text = unit.currentHP.ToString();
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
        currentHPText.text = hp.ToString();
    }

}
