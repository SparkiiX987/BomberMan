using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public List<Case> cases = new List<Case>();

    void Start()
    {
        int x = 1;
        int y = 1;

        foreach (Case _case in cases)
        {
            _case.x = x;
            _case.y = y;
            if (x == 9)
            {
                x = 1;
                y++;
            }
            else x++;
        }
    }
}
