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

        foreach(Case _case in cases)
        {
            int i = cases.IndexOf(_case);
            if(i + 1 < cases.Count && cases[i + 1] != null && _case.x != 16)
            {
                _case.right = cases[i + 1];
                _case.neighbours.Add(_case.right);
            }
            if (i - 1 > 0 && cases[i - 1] != null && _case.x != 1)
            {
                _case.left = cases[i - 1];
                _case.neighbours.Add(_case.left);
            }
            if (i + 16 < cases.Count && cases[i + 16] != null)
            {
                _case.up = cases[i + 16];
                _case.neighbours.Add(_case.up);
            }
            if (i - 16 > 0 && cases[i - 16] != null)
            {
                _case.down = cases[i - 16];
                _case.neighbours.Add(_case.down);
            }
        }
    }
}
