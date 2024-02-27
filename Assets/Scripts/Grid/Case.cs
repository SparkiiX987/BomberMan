using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Case : MonoBehaviour
{
    public int x, y; // Coordinate in grid
    [SerializeField] private bool walkable;
    [SerializeField] private bool hasUnite;
    public zoneType type;

    public Case up, down, left, right;
    public List<Case> neighbours = new List<Case>();

    [SerializeField] Material wall;
    [SerializeField] Material flore;


    //for PathFinding
    Case parent;

    int gCost;
    int hCost;
    int fCost 
    {  
        get { return gCost + hCost; } 
    }


    private void Start()
    {
        if (!walkable)
        {
            gameObject.GetComponent<Renderer>().material = wall;
        }
        RaycastHit2D hit;
        for (int i = -1; i < 2; i += 2)
        {
            hit = Physics2D.Raycast(transform.position, new Vector2(0, i), 11f);
            if (hit && hit.collider.gameObject.GetComponent<Case>())
            {
                if (i == -1)
                    down = hit.collider.gameObject.GetComponent<Case>();
                else
                    up = hit.collider.gameObject.GetComponent<Case>();
            }
            hit = Physics2D.Raycast(transform.position, new Vector2(i, 0), 11f);
            if (hit && hit.collider.gameObject.GetComponent<Case>())
            {
                if (i == -1)
                    left = hit.collider.gameObject.GetComponent<Case>();
                else
                    right = hit.collider.gameObject.GetComponent<Case>();
            }
        }
    }

    // Get Coordinate
    public int GetX() { return x; }
    public int GetY() { return y; }
    // Set Coordinate
    public void SetX(int nx) { x = nx; }
    public void SetY(int ny) { y = ny; }

    public bool IsWalkable() { return walkable; }
    public bool HasUnite() { return hasUnite; }





}

public enum zoneType
{
    Red,
    Blue,
    Neutral
}