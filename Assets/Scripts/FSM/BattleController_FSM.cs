using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController_FSM : MonoBehaviour
{

    #region Variables
    //player HUD
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public Unit playerUnit;
    public Unit enemyUnit;
    //Dialogue texts
    public Text dialogueText;
    public Text enemyBattleText;
    public Text playerBattleText;

    public Text playerSliceText;
    public Text playerStabText;
    public Text playerHealText;

    public Text enemySliceText;
    public Text enemyStabText;
    public Text enemyHealText;
    //check death status
    public bool enemyIsDead;
    public bool playerIsDead;
    //attack tracking variables
    public int attackNum;
    public List<AttackBase> theAttacks = new List<AttackBase>();
    public List<AttackBase> thePlayerAttacks = new List<AttackBase>();
    public AttackBase playerAttack;
    public AttackBase enemyAttack;

    #endregion
    private BattleBaseState currentState;
    public BattleBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly BattleStartState startState = new BattleStartState();
    public readonly BattlePlayerState playerState = new BattlePlayerState();
    public readonly BattleEnemyState enemyState = new BattleEnemyState();
    public readonly BattleAssessmentState assessmentState = new BattleAssessmentState();
    public readonly BattleWonState wonState = new BattleWonState();
    public readonly BattleLostState lostState = new BattleLostState();

    //FSM moves to start state
    private void Start()
    {
        TransitionToState(startState);
    }
    void Update()
    {
        currentState.Update(this);
    }
    public void TransitionToState(BattleBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    //player clicks stab
    public void OnClickStab()
    {
        currentState.OnClickStab(this);
    }
    //Player clicks slice
    public void OnClickSlice()
    {
        currentState.OnClickSlice(this);
    }
    //player clicks heal
    public void OnClickHeal()
    {
        currentState.OnClickHeal(this);
    }
}
