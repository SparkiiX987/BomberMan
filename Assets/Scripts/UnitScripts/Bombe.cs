using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe : MonoBehaviour
{
    public Unit unit;
    public Case currentCase;
    private float remainingTime = 5;


    private void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0)
        {
            Explosion();
        }
    }

    public void SetPositionToCase()
    {
        transform.position = new Vector3 (currentCase.transform.position.x, currentCase.transform.position.y, -3);
    }

    public void Explosion()
    {
        List<Unit> enemies = unit.unitsManager.ennemiesUnits.units;


        foreach (Case _case in currentCase.neighbours)
        {
            if (!_case.IsWalkable())
            {
                _case.DestroyWall();
            }
            else
            {
                foreach (Unit enemy in enemies)
                {
                    if (enemy.currentCase == _case)
                    {
                        enemy.TakeHit(20);
                    }
                }
            }
        }


        Destroy(gameObject);
    }

}
