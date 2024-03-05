using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
using Unity.VisualScripting.FullSerializer;

public class CheckForEnemyInAttackRange : Node
{
    public Unit unit;
    // private Animator animator
    public CheckForEnemyInAttackRange(Unit _unit)
    {
        unit = _unit;
        // animator = transform.GetComponent<Animator>();
    }


    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            Debug.Log("check range fail");
            state = NodeState.FAILURE;
            return state;
        }
        Unit targetUnit = (Unit)target;
        Case targetCase = targetUnit.currentCase;
        if (unit.currentCase.neighbours.Contains(targetCase))
        {
            // animator.SetBool("Attacking", true);
            // animator.SetBool("Walking", false);
            Debug.Log("check range sucess");
            state = NodeState.SUCCESS;
            return state;
        }
        Debug.Log("check range fail");
        state = NodeState.FAILURE;
        return state;
    }
}
