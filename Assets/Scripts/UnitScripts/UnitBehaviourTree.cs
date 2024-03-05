using System.Collections.Generic;
using BehaviourTree;

public class UnitBehaviourTree : Tree
{

    public Unit unit;
    public static int range;

    protected override Node SetupTree()
    {
        range = unit.range;

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckForEnemyInAttackRange(unit),
                new TaskAttackEnnemy(unit.GetAttackSpeed(), unit)
            }),

            new Sequence(new List<Node>
            {
                new CheckForRemainingEnemies(unit, unit.unitsManager),
                new TaskWalkToEnnemy(unit)
            })
        });

        return root;
    }
}
