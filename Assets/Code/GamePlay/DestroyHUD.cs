using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHUD : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.7f);
    }
}