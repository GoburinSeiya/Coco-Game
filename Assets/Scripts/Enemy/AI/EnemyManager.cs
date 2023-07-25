using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public bool isPerformingAction;
    public bool isInteracting;

    public EnemyMovement enemyMovement;
    public EnemyAnimationManager enemyAnimationManager;
    public EnemyStats enemyStats;
    public NavMeshAgent navMeshAgent;
    public Rigidbody enemyRB;

    public State currentState;

    public CharacterStats currentTarget;

    public float detectionRadius = 3.5f;
    public float maxDetectionAngle = 50;
    public float minDetectionAngle = -50;
    public float viewableAngle;

    public float distanceFromTarget;
    public float maxAttackRange;
    public float chaseSpeed;
    public float rotationSpeed;

    public float currentRecoveryTime = 0;

    private void Awake() 
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimationManager = GetComponent<EnemyAnimationManager>();
        enemyStats = GetComponent<EnemyStats>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyRB = GetComponent<Rigidbody>();
        navMeshAgent.enabled = false;
    }

    void Start()
    {
        enemyRB.isKinematic = false;
    }
    

    private void Update() 
    {
        HandleRecoveryTimer();

        isInteracting = enemyAnimationManager.animator.GetBool("isInteracting");
    }

    private void FixedUpdate() 
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        if(currentState != null)
        {
            State nextState = currentState.Tick(this, enemyStats, enemyAnimationManager);

            if(nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }

    private void HandleRecoveryTimer()
    {
        if(currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if(isPerformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPerformingAction = false;
            }
        }
    }

    private void SwitchToNextState(State state)
    {
        currentState = state;
    }
}
