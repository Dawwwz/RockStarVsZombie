using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public string leafLevel; 
    // Start is called before the first frame update
    void Start()
    {

        GameManager.instanceGameManager.leafLevel = leafLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
