using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnGestion : MonoBehaviour
{
    public HorizontalLayoutGroup roundCounter;
    public GameObject winIndicator;
    public List<GameObject> indicator = new List<GameObject>();
    public GameObject player1UI;
    public GameObject player2UI;
    public TextMeshProUGUI player1Timer;
    public TextMeshProUGUI player2Timer;
    public bool isPlayer1Turn;
    public bool isPlayer2Turn;
    public bool player1Win;
    public bool gameStarted;
    private float timer = 30;

    public Color[] indicatorColors;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject winInstance = Instantiate(winIndicator, roundCounter.transform);
            indicator.Add(winInstance);
        }
        isPlayer1Turn = true;
        isPlayer2Turn = false;
        gameStarted = false; 
    }

    public void Update()
    {
        WhichPlayerTurn();
        UpdateHUD();
    }

    public void WhichPlayerTurn()
    {
        if (isPlayer1Turn)
        {
            player1UI.SetActive(true);
            player2UI.SetActive(false);
        }
        else if (isPlayer2Turn)
        {
            player1UI.SetActive(false);
            player2UI.SetActive(true);
        }
    }

    public void UpdateHUD()
    {
        if (isPlayer1Turn || isPlayer2Turn)
        {
            timer -= Time.deltaTime;
            if (isPlayer1Turn)
                player1Timer.text = ("Timer : " + Mathf.Round(timer).ToString());
            else if (isPlayer2Turn)
                player2Timer.text = ("Timer : " + Mathf.Round(timer).ToString());

            if (timer <= 0)
            {
                EndTurn();
            }
        }
    }

    public void StartGame() 
    {
        gameStarted = true;
    }

    public void EndTurn()
    {
        if (isPlayer1Turn)
        {
            isPlayer1Turn = false;
            isPlayer2Turn = true;
            timer = 30; 
        }
        else if (isPlayer2Turn)
        {
            isPlayer1Turn = true;
            isPlayer2Turn = false;
            timer = 30;
        }
    }
}