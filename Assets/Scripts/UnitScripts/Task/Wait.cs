using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class Wait : Node
{

    public Wait()
    {

    }

    public override NodeState Evaluate()
    {
        Debug.Log("wait");
        state = NodeState.SUCCESS;
        return state;
    }
}
