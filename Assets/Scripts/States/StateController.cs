using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    
    public State currentState;
    // Start is called before the first frame update

    public void SetState(State state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
