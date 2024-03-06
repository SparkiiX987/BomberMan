using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnGestion : MonoBehaviour
{
    public HorizontalLayoutGroup roundCounter;
    public GameObject winIndicator;
    public List<GameObject> indicator = new List<GameObject>();
    public bool player1Win;
    public bool player2Win;

    public Color[] indicatorColors;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject winInstance = Instantiate(winIndicator, roundCounter.transform);
            indicator.Add(winInstance);
        }  
    }

    public void UpdateHUD()
    {
        if (player1Win)
        {
            
            player1Win = false;
        }
        else if (player2Win)
        {

            player2Win = false;
        }
    }
}
