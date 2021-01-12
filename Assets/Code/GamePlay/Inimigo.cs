
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inimigo : MonoBehaviour
{
    public Canvas hud;
    public GameObject lifeBarPref;
    public GameObject lifeBartrue;
    public Transform lifeBarPos;

    bool morreu = false;

    public bool explodiu;

    public Rigidbody2D inimigoRB;
    public float vidaMax;
    public float vida;
    public float velocidade;
    public bool podeDarDano;
    public float dano;
    public float attackSpeed;
    public GameObject coinGO;
    public GameObject leafGO;


    //check hit ball
    public Transform posicaoDaCabeça;
    public LayerMask bola;
    public float rangeDaCabeca;
    public bool colidiuComAbola;
    public bool pararDeColidir;



    public int leafChanceSpawn;



    // Start is called before the first frame update
    void Start()
    {
        // life bar
        GameObject aa = GameObject.Find("CanvasWS_Hud");
        hud = aa.GetComponent<Canvas>();
        GameObject a = Instantiate(lifeBarPref) as GameObject;
        lifeBartrue = a;
        lifeBartrue.transform.SetParent(hud.transform, true);
        lifeBartrue.transform.position = lifeBarPos.position;
        lifeBartrue.GetComponent<Image>().fillAmount = vida / vidaMax;

        if (gameObject.GetComponent<Rigidbody2D>().gravityScale == 0)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 3.4f);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (PlayerPrefs.GetInt("Level" + GameManager.instanceGameManager.levelBtnRef) == 0)
        {

            leafChanceSpawn = Random.Range(0, 2);

            switch (GameManager.instanceGameManager.scenaEmQueEstou)
            {
                case "Level1":
                    leafGO = GameManager.instanceGameManager.leaf[0];
                    break;
                case "Level2":
                    leafGO = GameManager.instanceGameManager.leaf[1];
                    break;
                case "Level3":
                    leafGO = GameManager.instanceGameManager.leaf[2];
                    break;
                case "Level4":
                    leafGO = GameManager.instanceGameManager.leaf[3];
                    break;
                case "Level5":
                    leafGO = GameManager.instanceGameManager.leaf[4];
                    break;
                case "Level6":
                    leafGO = GameManager.instanceGameManager.leaf[5];
                    break;
                case "Level7":
                    leafGO = GameManager.instanceGameManager.leaf[6];
                    break;
                case "Level8":
                    leafGO = GameManager.instanceGameManager.leaf[7];
                    break;
                case "Level9":
                    leafGO = GameManager.instanceGameManager.leaf[8];
                    break;

            }
        }




        inimigoRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        colidiuComAbola = Physics2D.OverlapCircle(posicaoDaCabeça.position, rangeDaCabeca, bola);
        if (colidiuComAbola)
        {
            print("oi"+ colidiuComAbola);
        }

    }
    private void FixedUpdate()
    {
        if (transform.position.y < -2.5)
        {
            transform.position = new Vector2(transform.position.x, -2.3f);
        }
        if (!pararDeColidir)
        {
            if (colidiuComAbola)
            {


                pararDeColidir = true;
                Player.rockModeCount++;
                
                if (Player.rockModeCount == 1)
                {
                    Player.ativandoAura = true;
                    Ballsapwn.ball_SpawnCD -= 1;
                }
                else if (Ballsapwn.ball_SpawnCD > 1.5f)
                {
                    Ballsapwn.ball_SpawnCD -= 0.5f;
                }
                Debug.Log(Ballsapwn.ball_SpawnCD);
                AudioManager.audioManager.guitarBGAS.volume = 1;
                StartCoroutine("CDheadshot");
            }
        }

        if (!explodiu)
        {
            Mov();
        }
        else if (explodiu)
        {
            StartCoroutine("CDMoV");
        }

     

      
        Vida();
        if (!morreu)
        {

            lifeBartrue.transform.position = lifeBarPos.position;
        }
        if (transform.position.x < -5)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;


            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        
    }

    void Mov()
    {
        inimigoRB.velocity = new Vector3(-velocidade, inimigoRB.velocity.y);
    }
    void Vida()
    {

        if (vida <= 0)
        {
            if (!morreu)
            {

                GameManager.instanceGameManager.zombiesAmount++;
                morreu = true;

            }
            Destroy(gameObject, 0.2f);
            lifeBartrue.GetComponent<DestroyHud1>().destroys = true;
            Instantiate(coinGO, transform.position, Quaternion.identity);
            if (GameManager.instanceGameManager.leafCanSpawn && PlayerPrefs.GetInt("Level" + GameManager.instanceGameManager.levelBtnRef) == 0 && leafChanceSpawn == 1)
            {
                GameManager.instanceGameManager.leafCanSpawn = false;
                Instantiate(leafGO, transform.position, Quaternion.identity);
            }

        }
    }


    public void corrotine()
    {
        StartCoroutine("CD");
    }
    IEnumerator CD()
    {

        yield return new WaitForSeconds(attackSpeed);

        podeDarDano = true;

    }
    IEnumerator CDMoV()
    {

        yield return new WaitForSeconds(1.5f);

        explodiu = false;

    }
    IEnumerator CDheadshot()
    {

        yield return new WaitForSeconds(0.9f);

        pararDeColidir = false ;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posicaoDaCabeça.position, rangeDaCabeca);
    }
    /*
    IEnumerator CdRock()
    {
        yield return new WaitForSeconds(2);
        pararDeColidir = false;
    }*/
}

