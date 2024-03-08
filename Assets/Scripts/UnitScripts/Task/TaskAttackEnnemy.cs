using BehaviourTree;
using UnityEngine;

public class TaskAttackEnnemy : Node
{
    public float attackCounter = 0f;
    public float attackTime;
    Unit self;
    // private Animator animator
    public TaskAttackEnnemy(float ac, Unit _self)
    {
        attackTime = ac;
        self = _self;
        // animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {

        Unit target = (Unit)GetData("target");

        attackCounter += Time.deltaTime;
        if(attackCounter >= attackTime)
        {
            bool enemyIsDead = target.TakeHit(self.GetAttack());
            if(enemyIsDead || target.unitIsDead)
            {
                ClearData("target");
                // animator.SetBool("Attacking", false);
                // animator.SetBool("Walking", true);
            }
            else
            {
                attackCounter = 0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

}
