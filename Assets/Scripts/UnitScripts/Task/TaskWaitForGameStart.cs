using BehaviourTree;

public class TaskWaitForGameStart : Node
{
    public Unit unit;

    public TaskWaitForGameStart(Unit _unit)
    {
        unit = _unit;
    }

    public override NodeState Evaluate()
    {
        if(!unit.gameStarted)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
        
    }
}