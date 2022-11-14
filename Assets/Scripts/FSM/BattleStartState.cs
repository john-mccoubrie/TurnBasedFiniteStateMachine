using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartState : BattleBaseState
{
    bool setupComplete = false;

    //FSM enters start state runs this code first
    public override void EnterState(BattleController_FSM battle)
    {
        Debug.Log("Start State");
        battle.enemyIsDead = false;
        battle.playerIsDead = false;
        battle.dialogueText.text = "Let the round begin...";

        //set up the battle space
        GameObject playerGO = GameObject.Instantiate(battle.playerPrefab, battle.playerBattleStation);
        battle.playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = GameObject.Instantiate(battle.enemyPrefab, battle.enemyBattleStation);
        battle.enemyUnit = enemyGO.GetComponent<Unit>();

        battle.playerHUD.SetHUD(battle.playerUnit);
        battle.enemyHUD.SetHUD(battle.enemyUnit);

        battle.StartCoroutine(SetupBattle());
    }
    //Gives each player 5 seconds before transitioning to the player state
    IEnumerator SetupBattle()
    {
        yield return new WaitForSeconds(5f);
        //set up the battle space is complete
        setupComplete = true;
    }
    public override void OnClickStab(BattleController_FSM battle)
    {
        
    }
    //once the set up is compelte - transition to player state
    public override void Update(BattleController_FSM battle)
    {
        if(setupComplete)
        {
            battle.TransitionToState(battle.playerState);
            setupComplete = false;
        }
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        
    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
        
    }
}
