using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public LeafControler leafControler;
    public string leafLevel; 
    // Start is called before the first frame update
    void Start()
    {
        leafControler = FindObjectOfType<LeafControler>();
        leafControler.Set_leaf_Level(leafLevel);
    }

}
