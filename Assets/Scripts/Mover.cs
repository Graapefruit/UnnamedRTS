using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Unit {
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
    private StateManager stateManager;
    private State idleState;
    private State moveState; 

    void Awake() {
        currentStatBlock = ScriptableObject.CreateInstance("CurrentStatBlock") as CurrentStatBlock;
        
        currentStatBlock.hp = baseStatBlock.maxHp;
        idleState = new State();
        moveState = new State();

        idleState.name = "Idle";
        moveState.name = "Moving";
        moveState.onEnter = (() =>  {
            animator.SetBool("IsMoving", true);
        });
        moveState.onExit = (() => {
            animator.SetBool("IsMoving", false);
        });
        moveState.onUpdate = (() => {
        });

        idleState.onGetNextState = (() => {
            if (agent.velocity.magnitude != 0.0f) {
                return moveState;
            } else {
                return idleState;
            }
        });

        moveState.onGetNextState = (() => {
            if (agent.velocity.magnitude == 0.0f) {
                return idleState;
            } else {
                return moveState;
            }
        });

        stateManager = new StateManager("Unit", idleState);
    }

    void Update() {
        stateManager.doUpdate();
    }
    public void move(Vector3 destination) {
        agent.destination = destination;
        agent.velocity = agent.velocity.normalized * agent.speed;
    }
}
