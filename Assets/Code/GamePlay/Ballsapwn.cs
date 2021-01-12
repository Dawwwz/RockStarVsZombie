using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ballsapwn : MonoBehaviour
{
    [Header("About Spawn ")]
    public int[] momentoNoTempoDoGame;
    public int[] inspectorSelectZombiess;
    public int[] zombie_SpawnNumberr;
    //BALL SPAWN
    [Header("Ball Spawn ")]
    public GameObject[] ball_GO;
    public Transform ball_SpawnPosition;
    public static  float ball_SpawnCD;
    public  bool ball_CanSpawn;
    // INIMIGO SPAWN
    public bool zombie_CanSPawns;
    [Header("Zombie Spawn ")]
    public GameObject[] zombie_GO;
    public Transform zombie_SpawnPosition;
    public float zombie_SpawnCD;
    public int zombie_SpawnNumber;
    
    public bool zombie_CanSPawn;
    public int inspectorSelectZombie;
   

    // CONTITION WIN AND VERIFY SE FAZE JA POSSUI LEAF
    [Header("Games Law")]
    public int  condition_zombiesKillForWinLevel;
    public int  condition_timeToLevelWinLevel;

    
    

    // Start is called before the first frame update
    void Start()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                AudioManager.audioManager.SoundBG(1);
                AudioManager.audioManager.guitarBG(1);
                break;
            case "Level2":
                AudioManager.audioManager.SoundBG(2);
                break;
            case "Level3":
                AudioManager.audioManager.SoundBG(3);
                break;
            case "Level4":
                AudioManager.audioManager.SoundBG(3);
                break;
            case "Level5":
                AudioManager.audioManager.SoundBG(4);
                break;
            case "Level6":
                AudioManager.audioManager.SoundBG(6);
                break;
            case "Level7":
                AudioManager.audioManager.SoundBG(5);
                break;
            case "Level8":
                AudioManager.audioManager.SoundBG(6);
                break;
            case "Level9":
                AudioManager.audioManager.SoundBG(5);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Win();
    }
    private void FixedUpdate()
    {
           if (zombie_CanSPawns)
           {
               if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[0])
                        {
                zombie_SpawnNumber = zombie_SpawnNumberr[0];
                            StartCoroutine("temporizadors");
                            SpawnOPs(inspectorSelectZombiess[0]);
                        }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[1])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[1];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[1]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[2])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[2];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[2]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[3])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[3];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[3]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[4])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[4];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[4]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[5])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[5];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[5]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[6])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[6];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[6]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[7])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[7];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[7]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[8])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[8];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[8]);
                }
                if (Mathf.Round(Hud.instance.time) == momentoNoTempoDoGame[9])
                {
                zombie_SpawnNumber = zombie_SpawnNumberr[9];
                StartCoroutine("temporizadors");
                    SpawnOPs(inspectorSelectZombiess[9]);
                }
           


            if (Hud.instance.time > 0)
                       {
             
                            if (zombie_CanSPawn)
                            {
                               zombie_CanSPawn = false;
                               SpawnOP();
                               StartCoroutine("temporizador");
                            }

                       }

                        if (ball_CanSpawn)
                        {
                            StartCoroutine("SSpawn");
                        }
           }

     }
    // BALL SPAWN

    IEnumerator SSpawn()
    {
        ball_CanSpawn = false;
        BallSpawn();
        yield return new WaitForSeconds(ball_SpawnCD);
       
        ball_CanSpawn = true;
    }
    void BallSpawn()
    {
        Instantiate(ball_GO[PlayerPrefs.GetInt("BallChosed")], ball_SpawnPosition.position, Quaternion.identity);
    }


    //
    // ZOMBIE SPAWN
    //
    IEnumerator temporizador()
    {
        zombie_CanSPawn = false;
        
        yield return new WaitForSeconds(zombie_SpawnCD);
       
        zombie_CanSPawn = true;
    }
    IEnumerator temporizadors()
    {
        zombie_CanSPawns = false;

        yield return new WaitForSeconds(zombie_SpawnCD);

        zombie_CanSPawns = true;
    }
    void SpawnOPs(int iinspectorSelectZombies)
    {
       

        for (int i = 0; i < zombie_SpawnNumber; i++)
        {
           
            Instantiate(zombie_GO[iinspectorSelectZombies], zombie_SpawnPosition.position, Quaternion.identity);

        }
        
     
    }
    void SpawnOP()
    {

        Instantiate(zombie_GO[inspectorSelectZombie], new Vector3(zombie_SpawnPosition.position.x + Random.Range(-2, 2), zombie_SpawnPosition.position.y), Quaternion.identity);
        

    }



    // REGRAS DO GAME
    void Win()
    {
        
        GameObject[] verLeaf = GameObject.FindGameObjectsWithTag("leaf");
       

       
        

            if (Hud.instance.time <= 0 && Hud.zombienaTela == 0 && verLeaf.Length == 0)
            {
                if (PlayerPrefs.GetInt("Level2") == 1)
                {

                StartCoroutine("Wins");

                }
                else if (PlayerPrefs.GetInt("freelevel" +2) == 0)
                {
                    GameObject[] verMoeda = GameObject.FindGameObjectsWithTag("Coin");
                    if(verMoeda.Length == 0)
                    {
                         StartCoroutine("Wins");

                    }
                }


            }
       
    }
    IEnumerator Wins()
    {
        yield return new WaitForSeconds(3);
        GameManager.instanceGameManager.gameWin = true;
    }
}
