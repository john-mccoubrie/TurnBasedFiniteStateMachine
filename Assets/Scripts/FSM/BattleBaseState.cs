using UnityEngine;

public abstract class BattleBaseState
{
    public abstract void EnterState(BattleController_FSM battle);
    public abstract void Update(BattleController_FSM battle);
    public abstract void OnClickStab(BattleController_FSM battle);
    public abstract void OnClickSlice(BattleController_FSM battle);
    public abstract void OnClickHeal(BattleController_FSM battle);
}
