using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlice : AttackBase
{

    public AttackSlice()
    {
        damage = 5;
    }
    public override int DamageOpponent()
    {
        base.damage = 5;
        return base.damage;
    }
}
