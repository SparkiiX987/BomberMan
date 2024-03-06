using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

public class UnitBehaviourTree : Treee
{

    public Unit unit;
    public string enemyTag;
    public LayerMask enemyLayer;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckForEnemyInAttackRange(unit, enemyTag, unit.rangeWithItem, enemyLayer),
                new TaskAttackEnnemy(unit.GetAttackSpeed(), unit)
            }),

            new Sequence(new List<Node>
            {
                new CheckForRemainingEnemies(unit, unit.unitsManager),
                new TaskWalkToEnnemy(unit)
            }),
            new Wait()

        }) ;

        return root;
    }
}
