using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckForRemainingEnemies : Node
{
    public Unit unit;
    public UnitsManager unitsManager;
    // private Animator animator

    public CheckForRemainingEnemies(Unit _unit, UnitsManager _unitsManager) 
    {
        unit = _unit;
        unitsManager = _unitsManager;
        // animator = transform.GetComponent<Animator>();
    }



    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            if (unitsManager.ennemiesUnits.units.Count == 0)
            {
                state = NodeState.FAILURE;
                return state;
            }
                
            Collider[] colliders = Physics.OverlapSphere(unit.transform.position, 500);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<Unit>(out Unit _unit) && unitsManager.ennemiesUnits.units.Contains(_unit))
                {
                    parent.parent.SetData("target", _unit);
                    // animator.SetBool("Walking", true);
                    Debug.Log("check remaining sucess");
                    state = NodeState.SUCCESS;
                    return state;
                }
            }
            Debug.Log("check remaining fail");
            state = NodeState.FAILURE;
            return state;
        }
        Debug.Log("check remaining sucess");
        state = NodeState.SUCCESS;
        return state;
    }
}