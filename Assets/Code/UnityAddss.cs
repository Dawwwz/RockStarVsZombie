using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class UnityAddss : MonoBehaviour
{
    public static UnityAddss instance;
    public string gameID = "3911345";
   void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    void Start()
    {
        Advertisement.Initialize(gameID, false);
    }

    public void ChamandoAdd()
    {
        if (PlayerPrefs.HasKey("Add"))
        {
            if(PlayerPrefs.GetInt("Add") == 3)
            {
                if (Advertisement.IsReady("video"))
                {
                    Advertisement.Show("video");
                    PlayerPrefs.SetInt("Add", 1);
                }
            }
            else
            {
              PlayerPrefs.SetInt("Add", PlayerPrefs.GetInt("Add") + 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Add", 1);
        }

    }
}
