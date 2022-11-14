using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWonState : BattleBaseState
{
    public override void EnterState(BattleController_FSM battle)
    {
        Debug.Log("Won");
    }

    public override void OnClickStab(BattleController_FSM battle)
    {
        throw new System.NotImplementedException();
    }

    public override void OnClickHeal(BattleController_FSM battle)
    {
        throw new System.NotImplementedException();
    }

    public override void OnClickSlice(BattleController_FSM battle)
    {
        throw new System.NotImplementedException();
    }

    public override void Update(BattleController_FSM battle)
    {
        
    }
}
