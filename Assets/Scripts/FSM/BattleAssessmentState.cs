using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAssessmentState : BattleBaseState
{
    int enemyDamage;
    int playerDamage;
    public override void EnterState(BattleController_FSM battle)
    {
        Debug.Log("Assessment State");
        #region Compare Attacks
        //each attack types associated interactions

        //slice vs slice both players deal equal damage
        //slice vs stab the player stabbing deals 50% less damage
        //slice vs heal player healing heals 10
        if(battle.playerAttack.attackType == AttackType.SLICE)
        {
            switch (battle.enemyAttack.attackType)
            {
                case AttackType.SLICE:
                    playerDamage = battle.playerAttack.damage;
                    enemyDamage = battle.enemyAttack.damage;
                    break;
                case AttackType.STAB:
                    playerDamage = battle.playerAttack.damage;
                    enemyDamage = battle.enemyAttack.damageReduced;
                    break;
                case AttackType.HEAL:
                    battle.enemyUnit.currentHP += 10;
                    break;
            }
        }
        //stab vs stab both players deal equal damage
        //stab vs heal healing player loses double damage
        if(battle.playerAttack.attackType == AttackType.STAB)
        {
            switch (battle.enemyAttack.attackType)
            {
                case AttackType.SLICE:
                    playerDamage = battle.playerAttack.damageReduced;
                    enemyDamage = battle.enemyAttack.damage;
                    break;
                case AttackType.STAB:
                    playerDamage = battle.playerAttack.damageReduced;
                    enemyDamage = battle.enemyAttack.damageReduced;
                    break;
                case AttackType.HEAL:
                    playerDamage = battle.playerAttack.damageCritical;
                    break;
            }
        }
        //heal vs heal both players heal equal health
        if(battle.playerAttack.attackType == AttackType.HEAL)
        {
            switch (battle.enemyAttack.attackType)
            {
                case AttackType.SLICE:
                    battle.playerUnit.currentHP += battle.playerAttack.heal;
                    playerDamage = battle.playerAttack.damageMissed;
                    enemyDamage = battle.enemyAttack.damageMissed;
                    break;
                case AttackType.STAB:
                    playerDamage = battle.playerAttack.damageMissed;
                    enemyDamage = battle.enemyAttack.damageCritical;
                    break;
                case AttackType.HEAL:
                    battle.playerUnit.currentHP += battle.playerAttack.heal;
                    battle.enemyUnit.currentHP += 10;
                    break;
            }
        }
        #endregion

        #region Player/Enemy Attacks
        //enemy attack
        battle.playerIsDead = battle.playerUnit.TakeDamage(enemyDamage);
        battle.playerHUD.SetHP(battle.playerUnit.currentHP);

        //player attack
        battle.enemyIsDead = battle.enemyUnit.TakeDamage(playerDamage);
        battle.enemyHUD.SetHP(battle.enemyUnit.currentHP);
        #endregion

        #region Check Death
        //determines next state -- if the player or enemy is dead move to won/lost state
        //if no one is dead -- FSM returns to the player state (players turn again)
        if (battle.enemyIsDead)
        {
            battle.TransitionToState(battle.wonState);
        }
        else if (battle.playerIsDead)
        {
            battle.TransitionToState(battle.lostState);
        }
        else
        {
            battle.TransitionToState(battle.playerState);
        }

        #endregion
    }

    public override void OnClickStab(BattleController_FSM battle)
    {

    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
       
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        
    }

    public override void Update(BattleController_FSM battle)
    {
        
    }
}
