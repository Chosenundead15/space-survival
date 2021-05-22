using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public abstract class State : ScriptableObject
{
    public abstract void EnterState(StateController controller);

    public abstract void UpdateState(StateController controller);
}
