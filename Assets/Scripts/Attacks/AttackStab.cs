using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStab : AttackBase
{
    public AttackStab()
    {
        damage = 10;
    }
    public override int DamageOpponent()
    {
        base.damage = 10;
        return base.damage;
    }
}
