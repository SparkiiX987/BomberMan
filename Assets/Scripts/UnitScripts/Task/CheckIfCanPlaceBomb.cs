using BehaviourTree;
using UnityEngine;

public class CheckIfCanPlaceBomb : Node
{
    public float BombeCounter = 0;
    public float BombeTime;
    Unit unit;
    
    public CheckIfCanPlaceBomb(Unit _unit, float ats)
    {
        unit = _unit;
        BombeTime = ats;
    }

    public override NodeState Evaluate()
    {
        BombeCounter += Time.deltaTime;
        if(BombeCounter >= BombeTime)
        {
            BombeCounter = 0;
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }

}
