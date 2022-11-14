using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerState : BattleBaseState
{
    public int playerSliceCount = 5;
    public int playerStabCount = 2;
    public int playerHealCount = 2;

    //upon entering the state informs the player it is their turn
    public override void EnterState(BattleController_FSM battle)
    {
        Debug.Log("Player");

        battle.dialogueText.text = "Your turn, attack!";
    }
    //Once the player chooses their attack, automatically transitions to the enemy state
    //Chosen attack counter subtracted once
    public override void OnClickStab(BattleController_FSM battle)
    {
        if(playerStabCount > 0)
        {
            battle.playerAttack = battle.thePlayerAttacks[1];
            battle.playerBattleText.text = battle.playerAttack.attackType.ToString();
            playerStabCount--;
            battle.playerStabText.text = playerStabCount.ToString();
            battle.TransitionToState(battle.enemyState);
        }     
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        if(playerSliceCount > 0)
        {
            battle.playerAttack = battle.thePlayerAttacks[0];        
            battle.playerBattleText.text = battle.playerAttack.attackType.ToString();
            playerSliceCount--;
            battle.playerSliceText.text = playerSliceCount.ToString();
            battle.TransitionToState(battle.enemyState);
        }
        
    }
    public override void Update(BattleController_FSM battle)
    {
        
    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
        if(playerHealCount > 0)
        {
            battle.playerAttack = battle.thePlayerAttacks[2];
            battle.playerBattleText.text = battle.playerAttack.attackType.ToString();
            playerHealCount--;
            battle.playerHealText.text = playerHealCount.ToString();
            battle.TransitionToState(battle.enemyState);
        }    
    }
}
