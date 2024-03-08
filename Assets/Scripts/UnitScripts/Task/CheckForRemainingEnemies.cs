using BehaviourTree;
using UnityEngine;

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
            if (unitsManager.ennemiesUnits.Instanciatedunits.Count == 0)
            {
                state = NodeState.FAILURE;
                return state;
            }
                
            Collider[] colliders = Physics.OverlapSphere(unit.transform.position, 5000);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<Unit>(out Unit _unit) && unitsManager.ennemiesUnits.Instanciatedunits.Contains(_unit))
                {
                    parent.parent.SetData("target", _unit);
                    // animator.SetBool("Walking", true);
                    state = NodeState.SUCCESS;
                    return state;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }
        Unit enemy = (Unit)target;
        if ((unit.targetCase == unit.caseThatContainTargetEnnemy) || (enemy.currentCase == unit.targetCase))
        {
            state = NodeState.FAILURE;
            return state;
        }
        state = NodeState.SUCCESS;
        return state;
    }
}