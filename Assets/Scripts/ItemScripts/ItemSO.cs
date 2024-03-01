using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    public int id;
    public string name;
    public Sprite icon;
    public Sprite border;
    public int hp;
    public int atk;
    public float ats;
    public float ms;
}
