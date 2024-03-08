using BehaviourTree;
using UnityEngine;

public class CheckForEnemyInAttackRange : Node
{
    public Unit unit;
    public string enemytag;
    public int range;
    public LayerMask enemyLayer;
    // private Animator animator
    public CheckForEnemyInAttackRange(Unit _unit, string tag, int _range, LayerMask layer)
    {
        unit = _unit;
        enemytag = tag;
        range = _range;
        enemyLayer = layer;
        // animator = transform.GetComponent<Animator>();
    }


    public override NodeState Evaluate()
    {
        object target = GetData("target");
        if (target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        Unit targetUnit = (Unit)target;
        if (Vector3.Distance(unit.transform.position, targetUnit.transform.position) <= range)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
