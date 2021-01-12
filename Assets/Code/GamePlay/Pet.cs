using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class Pet : MonoBehaviour
{
    
    
    public Canvas hud;
    public GameObject lifeBarPref;
    public GameObject lifeBarTrue;
    public Transform lifeBarPos;
    public Rigidbody2D petRB;
    public bool voltando;
    public float vel;
    public bool pegaxxx = false;
    public bool leaf;
    public float vida;
    public float petVidaMax;
    public bool buffado;
    public bool podeDarDano;
    public float attackSpeed;
    public float petDano;
    public bool petTelp;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject hudTemp = GameObject.Find("CanvasWS_Hud");
        hud = hudTemp.GetComponent<Canvas>();
        GameObject barTemp = Instantiate(lifeBarPref) as GameObject;
        lifeBarTrue = barTemp;
        lifeBarTrue.transform.SetParent(hud.transform, false);
        lifeBarTrue.transform.position = lifeBarPos.position;
        lifeBarTrue.GetComponent<Image>().fillAmount = vida / petVidaMax;

        petRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    private void FixedUpdate()
    {
       if(vida > petVidaMax)
        {
            vida = petVidaMax;
        }
        if (pegaxxx && transform.position.y <= 0)
        {
            if ( !voltando && petTelp && buffado)
            {

                if (transform.position.y < -2.5)
                {
                    transform.position = new Vector2(transform.position.x, -2.3f);
                }
                GameObject[] ver = GameObject.FindGameObjectsWithTag("inimigo");
                for (int i = 0; i < ver.Length; i++)
                {
                    if (ver[i].transform.position.x <= transform.position.x && ver[i].transform.position.y >= 2.7)
                    {

                        petTelp = false;
                        StartCoroutine("CDtelep");
                        transform.position = new Vector2(ver[i].transform.position.x - 1f, ver[i].transform.position.y + 1);
                    }
                }
            }
            GetComponent<Animator>().SetBool("andando", true);
            petRB.velocity = new Vector3(vel, petRB.velocity.y);
            
            
        }
        else
        {
            GetComponent<Animator>().SetBool("andando", false);
        }

        //
        //CONDIÇÕES PARA VOLTAR
        //
        if (vel > 0)
        {
            // AJEITAR PARADA DA FOLLHAAA SKALE E VOLTAR NAO TA COLIDINDO QUANDO VOLTAA
                  if (vida <= 0 || transform.position.x > 12.5f /* || transform.childCount > 1*/)
                {
                    gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(gameObject.GetComponent<CapsuleCollider2D>().size.x, 1);
                    gameObject.transform.localScale = new Vector2(1, 1);
                    gameObject.GetComponent<CapsuleCollider2D>().usedByEffector = true;
                    vel = 5;
                    vel *= -1;
                    voltando = true;
                }
        }

        //
        //coNDIÇÃO PARA IR DNV
        //
        if (vel < 0)
        {
            
            if (transform.position.x < -9)
                {
              
                pegaxxx = false;
                gameObject.GetComponent<CapsuleCollider2D>().usedByEffector = false;
                vel = -2;
                vel = vel * -1;
                vida = petVidaMax;
                lifeBarTrue.GetComponent<Image>().fillAmount = vida / petVidaMax;
                voltando = false;
                }

            if (leaf)
            {

                
            }
        }
    
        lifeBarTrue.transform.position = lifeBarPos.position;
    }

    public void Mov()
    {
        pegaxxx = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag ("Coin") )
        {
            Destroy(collision.gameObject);
            GameManager.instanceGameManager.coinEphemeral += 100;
           
            Hud.instance.AttHuds();
        }

        if (collision.gameObject.CompareTag("leaf"))

        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            collision.gameObject.transform.SetParent(transform, true);
            collision.transform.position = new Vector2(transform.position.x , transform.position.y + 1.2f) ;
            leaf = true;
            
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;


        }
        if (collision.gameObject.CompareTag("inimigo"))
        {
              
            if (!voltando)
            {
                Inimigo a = collision.gameObject.GetComponent<Inimigo>();
                if (a != null)
                {
                    if (vida > 0)
                    {
                        if (a.podeDarDano)
                        {
                            a.podeDarDano = false;
                            a.corrotine();
                            vida -= a.dano;
                            HudHPUp();
                        }
                        if (buffado)
                        {

                            if (podeDarDano)
                            {

                                podeDarDano = false;
                                StartCoroutine("CD");
                                a.vida -= petDano;
                                a.lifeBartrue.GetComponent<Image>().fillAmount = a.vida / a.vidaMax;
                            }
                        }
                    }
                } 
            }
        } 
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            if (!voltando)
            {

                Inimigo  a = collision.gameObject.GetComponent<Inimigo>();
                if (a != null)
                {

                    if(vida > 0)
                    {
                        if (a.podeDarDano)
                        {
                            a.podeDarDano = false;
                            a.corrotine();
                            vida -= a.dano;
                            HudHPUp();
                        }
                        if (buffado)
                        {

                            if (podeDarDano)
                            {
                           
                                gameObject.transform.localScale = new Vector2(1, 2.4f);
                              
                                podeDarDano = false;
                                StartCoroutine("CD");
                                a.vida -= petDano;
                                a.lifeBartrue.GetComponent<Image>().fillAmount = a.vida / a.vidaMax;
                            }
                            else if (!podeDarDano && !voltando && petTelp)
                            {
                                
                                GameObject[] verificaInimigo = GameObject.FindGameObjectsWithTag("inimigo");
                                for (int i = 0; i < verificaInimigo.Length; i++)
                                {
                                    if (verificaInimigo[i].transform.position.x <= transform.position.x && verificaInimigo[i].transform.position.y >= 2.7)
                                    {
                                        petTelp = false;
                                        StartCoroutine("CDtelep");
                                        transform.position = new Vector2(verificaInimigo[i].transform.position.x - 1f, verificaInimigo[i].transform.position.y + 1);
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            if(transform.childCount > 1)
            {

                if (leaf)
                {
                    transform.GetChild(1).gameObject.tag = "Untagged";
                    GameObject lef = transform.GetChild(1).gameObject;
                     lef.transform.SetParent(collision.transform, true);
                    lef.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 1.6f);
                    GameManager.instanceGameManager.leafCatch = true;         
                }
            }
        }
    }
    
    

    public void HudHPUp()
    {
        
        
        lifeBarTrue.GetComponent<Image>().fillAmount = vida / petVidaMax;

        
        
    }
    IEnumerator CD()
    {

        yield return new WaitForSeconds(attackSpeed);

        podeDarDano = true;

    }
    IEnumerator CDtelep()
    {
        yield return new WaitForSeconds(2);
        petTelp = true;
    }
}
