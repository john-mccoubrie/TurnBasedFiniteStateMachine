using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyState : BattleBaseState
{
    bool enemyAttackComplete = false;
    public int enemySliceCount = 5;
    public int enemyStabCount = 2;
    public int enemyHealCount = 2;
    //start state prints "enemy" to test program has moved to the enemy state
    public override void EnterState(BattleController_FSM battle)
    {
        Debug.Log("Enemy");
        battle.dialogueText.text = "The enemy is up!";
    }
    public IEnumerator EnemyAttackTimer()
    {
        yield return new WaitForSeconds(5);
        enemyAttackComplete = true;
    }

    //Once the player chooses their attack, automatically transitions to the assessment state
    //Chosen attack counter subtracted once
    public override void OnClickStab(BattleController_FSM battle)
    {
        battle.enemyAttack = battle.theAttacks[1];
        battle.enemyBattleText.text = battle.theAttacks[1].attackType.ToString();
        enemyStabCount--;
        battle.enemyStabText.text = enemyStabCount.ToString();
        battle.TransitionToState(battle.assessmentState);
    }

    public override void Update(BattleController_FSM battle)
    {
        
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        battle.enemyAttack = battle.theAttacks[0];
        battle.enemyBattleText.text = battle.theAttacks[0].attackType.ToString();
        enemySliceCount--;
        battle.enemySliceText.text = enemySliceCount.ToString();
        battle.TransitionToState(battle.assessmentState);
    }
    public override void OnClickHeal(BattleController_FSM battle)
    {
        battle.enemyAttack = battle.theAttacks[2];
        battle.enemyBattleText.text = battle.theAttacks[2].attackType.ToString();
        enemyHealCount--;
        battle.enemyHealText.text = enemyHealCount.ToString();
        battle.TransitionToState(battle.assessmentState);
    }
}
