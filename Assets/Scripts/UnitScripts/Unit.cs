using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private int id;
    private string unitName;
    private int hp;
    private int atk;
    private float ms = 1;
    private float ats;
    private int range;
    private int ultCharges;
    private bool canMove = true;

    public Case currentCase;
    public Case targetCase;
    public Case caseThatContainTargetEnnemy;

    // GeneralItiem item1
    // UniqueItiem item2


    private void Update()
    {
        if (canAttack())
        {
            print("attack");
        }
        else if (canMove)
        {
            Move();
            if(Vector3.Distance(targetCase.transform.position, currentCase.transform.position) > 10f)
            {
                canMove = true;
            }
        }
    }

    private bool canAttack()
    {
        return caseThatContainTargetEnnemy.neighbours.Contains(currentCase);
    }

    private void Move()
    {
        canMove = false;
        foreach (Case _case in currentCase.neighbours)
        {
            if (_case == targetCase) 
            {
                MoveToCase(targetCase);
            }
        }

        MoveToCase(PathFinding(currentCase, targetCase));
    }

    private void MoveToCase(Case caseToMove)
    {
        transform.position = Vector3.MoveTowards(transform.position, caseToMove.transform.position, ms * Time.deltaTime);
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
        Case currentCase = end;
        while (currentCase.parent != start)
        {
            currentCase = currentCase.parent;
        }
        return currentCase;
    }

}
