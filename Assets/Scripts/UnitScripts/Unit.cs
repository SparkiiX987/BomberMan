using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int id;
    private string unitName;

    public Sprite unitIcon;

    [SerializeField] private int hp;
    [SerializeField] private int atk;
    [SerializeField] private float ms = 15;
    [SerializeField] private float ats = 2;
    [SerializeField] private int range;
    [SerializeField] private int ultCharges;


    [SerializeField] private int hpWithItem;
    [SerializeField] private int atkWithItem;
    [SerializeField] private float msWithItem = 15;
    [SerializeField] private float atsWithItem;
    [SerializeField] private int rangeWithItem;
    [SerializeField] private int ultChargesWithItem;

    private bool canMove = true;
    private bool isMoving;
    public UnitsManager unitsManager;
    private Unit targetUnit;
    private float attackCooldown = 0;

    public Case currentCase;
    public Case targetCase;
    public Case caseThatContainTargetEnnemy;

    // GeneralItiem item1
    // UniqueItiem item2

    /*
        public void UpdateStats(GeneralItiem item1 = null, UniqueItiem item2 = null)
        {
            hpWithItem = hp;
            atkWithItem = atk;
            msWithItem = ms;
            atsWithItem = ats;
            rangeWithItem = hp;
            ultChargesWithItem = hp;
            if(item1 == null && item2 == null)
            {
                return;
            }
            
            if(item1 != null)
            {
                hpWithItem += item1.hp;
                atkWithItem += item1.atk;
                msWithItem += item1.ms;
                atsWithItem += item1.ats;
            }
            if(item1 != null)
            {
                hpWithItem += item2.hp;
                atkWithItem += item2.atk;
                msWithItem += item2.ms;
                atsWithItem += item2.ats;
                rangeWithItem += item2.range;
                ultChargesWithItem += item2.ultCharge;
            }
        }
    */

    private void Start()
    {
        hpWithItem = hp;
        atkWithItem = atk;
        msWithItem = ms;
        atsWithItem = ats;
        rangeWithItem = range;
        ultChargesWithItem = ultCharges;
    }

    private void Update()
    {
        if(attackCooldown < ats)
        {
            attackCooldown += Time.deltaTime;
        }
        if (canAttack() && !isMoving && attackCooldown >= ats)
        {
            Attack();
        }
        else if (canMove)
        {
            canMove = false;
            isMoving = true;
            currentCase = targetCase;
            targetCase = PathFinding(currentCase, caseThatContainTargetEnnemy);
            if (targetCase == caseThatContainTargetEnnemy)
            {
                isMoving = false;
                canMove = true;
            }
        }
        if(isMoving)
        {
            MoveToCase(targetCase);
            if (Vector3.Distance(transform.position, targetCase.transform.position) < 4.5f)
            {
                transform.position = new Vector3 (targetCase.transform.position.x, targetCase.transform.position.y, -5f);
                canMove = true;
                isMoving = false;
                if (FindEnnemyCase() != null)
                    caseThatContainTargetEnnemy = FindEnnemyCase();
            }
        }
    }

    private bool canAttack()
    {
        return caseThatContainTargetEnnemy.neighbours.Contains(currentCase);
    }

    private void MoveToCase(Case caseToMove)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3 (caseToMove.transform.position.x, caseToMove.transform.position.y, -5f), ms * Time.deltaTime);
    }


    public Case PathFinding(Case start, Case end)
    {

        List<Case> open = new List<Case>(); // cases that will be examinate
        HashSet<Case> closed = new HashSet<Case>(); // cases already examinate
        open.Add(start); // the start case to the examination list

        while (open.Count > 0) // while all cases are not examinate
        {
            Case currentCase = open[0];
            for (int i = 1; i < open.Count; i++)
            {
                if (open[i].fCost < currentCase.fCost || open[i].fCost == currentCase.fCost && open[i].hCost < currentCase.hCost) // search the less costly case to reach
                {
                    currentCase = open[i];
                }
            }
            // count this case as an examinate
            open.Remove(currentCase);
            closed.Add(currentCase);

            // if its the end
            if (currentCase == end)
            {
                return GetNextCaseToReach(end, start);
            }

            foreach (Case neighbour in currentCase.neighbours) // search in all neighbour cases 
            {
                if (neighbour == null || closed.Contains(neighbour)) continue;


                bool canReachNeighbourCase = false;

                // verifie if from the current case you can reach the neigbour case
                if ((currentCase.left == neighbour && neighbour.IsWalkable())
                || (currentCase.right == neighbour && neighbour.IsWalkable())
                || (currentCase.up == neighbour && neighbour.IsWalkable())
                || (currentCase.down == neighbour && neighbour.IsWalkable()))
                {
                    canReachNeighbourCase = true;
                }


                if (!canReachNeighbourCase) // if the neighbour is not reachable
                {
                    continue;
                }


                int newMovementCostToNeighbour = currentCase.gCost + GetDistance(currentCase, neighbour); // calculate the new movement cost to this neighbour
                if (newMovementCostToNeighbour < neighbour.gCost || !open.Contains(neighbour))
                {
                    // update the g cost and the h cost of this neigbour
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, end);
                    neighbour.parent = currentCase;
                    // if this neigbour is not in the open list add him to it
                    if (!open.Contains(neighbour))
                        open.Add(neighbour);
                }
            }
        }
        // no path as been founded
        return null;
    }

    private int GetDistance(Case caseA, Case caseB)
    {
        if (caseA == null || caseB == null)
            return 0;
        int distX = caseA.x - caseB.x;
        int distY = caseA.y - caseB.y;
        if (distX > distY)
            return 2 * distY + (distX - distY);

        return 2 * distX + (distY - distX);
    }

    private Case GetNextCaseToReach(Case end, Case start)
    {
        Case _currentCase = end;
        while (_currentCase.parent != start)
        {
            _currentCase = _currentCase.parent;
        }
        return _currentCase;
    }

   private Case FindEnnemyCase()
    {
        List<Unit> ennemiesUnits = unitsManager.ennemiesUnits.units;
        if (unitsManager.ennemiesUnits.units.Count == 0)
            return null;
        float minDist = Vector3.Distance(transform.position, ennemiesUnits[0].transform.position);
        int index = 0;
        for(int i = 1; i < ennemiesUnits.Count; i++)
        {
            if (Vector3.Distance(transform.position, ennemiesUnits[i].transform.position) < minDist)
            {
                index = i;
                minDist = Vector3.Distance(transform.position, ennemiesUnits[i].transform.position);
            }
        }
        targetUnit = ennemiesUnits[index];
        return ennemiesUnits[index].currentCase;

    }
    
    private void Attack()
    {
        print("attack");
        attackCooldown = 0;
        print(targetUnit);
        targetUnit.AddHP(-atkWithItem);

    }

    public void AddHP(int damages)
    {
        hpWithItem += damages;
        if(hpWithItem <= 0)
        {
            unitsManager.units.Remove(gameObject.GetComponent<Unit>());
            Destroy(gameObject);
        }
    }

}
