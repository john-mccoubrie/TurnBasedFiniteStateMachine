using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { SLICE, STAB, HEAL }
public class AttackBase : MonoBehaviour
{
    public AttackType attackType ;
    public string type;
    public int damage;
    public int damageCritical;
    public int damageReduced;
    public int damageBlocked;
    public int damageMissed;
    public int heal;
    //damage reduced refers to slice vs stab combos
    //damaged block refers to stab vs stab combos
    //damaged missed refers to heal vs heal combos
    public void SetAttacks()
    {
        attackType = AttackType.SLICE;
        damage = 5;
        damageReduced = 3;
        damageBlocked = 2;
        damageMissed = 0;
    }
    public virtual int DamageOpponent()
    {
        return damage;
    }
}
