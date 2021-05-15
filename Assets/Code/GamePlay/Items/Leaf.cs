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
    private void LateUpdate()
    {
        if (transform.position.x > 8.50 && transform.position.x < -8.70 && transform.position.y < -4)
        {
            transform.position = new Vector3(8.5f, -1);
        }
    }

}
