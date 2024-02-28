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

            if (_case.y >= 1 && _case.y <= 4)
            {
                _case.type = zoneType.Blue;
            }
            else if(_case.y >= 14 && _case.y <= 16)
            {
                _case.type = zoneType.Red;
            }
            else
            {
                _case.type = zoneType.Neutral;
            }

            if (x == 16)
            {
                x = 1;
                y++;
            }
            else x++;
        }
    }
}
