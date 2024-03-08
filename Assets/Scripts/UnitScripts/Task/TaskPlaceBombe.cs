using BehaviourTree;
using UnityEngine;

public class TaskPlaceBombe : Node
{

    public GameObject bomb;
    public Unit unit;

    public TaskPlaceBombe(GameObject bombe, Unit _unit)
    {
        bomb = bombe;
        unit = _unit;
    }

    public override NodeState Evaluate()
    {
        GameObject newBomb = GameObject.Instantiate(bomb);
        unit.bombs.Add(newBomb);
        newBomb.GetComponent<Bombe>().currentCase = unit.currentCase;
        newBomb.GetComponent<Bombe>().units = unit.unitsManager;
        newBomb.GetComponent<Bombe>().SetPositionToCase();

        state = NodeState.RUNNING;
        return state;
    }
}
