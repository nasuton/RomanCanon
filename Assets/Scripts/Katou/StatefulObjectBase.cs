using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class StatefulObjectBase<T, TEnmu> : MonoBehaviour
    where T : class where TEnmu : System.IConvertible
{
    protected List<State<T>> stateList = new List<State<T>>();

    protected StateMachine<T> stateMachine;

    public virtual void ChangeState(TEnmu state)
    {
        if(stateMachine == null)
        {
            return;
        }
        stateMachine.ChangeState(stateList[state.ToInt32(null)]);
    }

    public virtual bool IsCurrentState(TEnmu state)
    {
        if(stateMachine == null)
        {
            return false;
        }

        return stateMachine.CurrentState == stateList[state.ToInt32(null)];
    }

	protected virtual void Update ()
    {
	    if(stateMachine != null)
        {
            stateMachine.Update();
        }
	}

}
