using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class TaskWalkToEnnemy : Node
{
    public Unit unit;
    public TaskWalkToEnnemy(Unit _unit) 
    {
        unit = _unit;
    }
    
    public override NodeState Evaluate()
    {
        Unit enemy = (Unit)GetData("target");
        unit.caseThatContainTargetEnnemy = enemy.currentCase;

        if (unit.canMove)
        {
            unit.SetTargetCase();
        }

        state = NodeState.RUNNING;
        return state;
    }
}
