using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public ParticleSystem sayajin;
    public GameObject refsp;
    public GameObject part;
    public TrailRenderer trailrender;
    public Animator rig;
    public Button pet;
    // arrow reticle
    public float rotvel = 200;
    public float rotvelSave;
    public float arrowZRotate, arrowY;
    public Image arrowBG, arrowBGs;
    public Transform startPosRef, startpositionUIangle;
    public float x;
    public float y;
    public float rot;
    // PROPRIEDADES DA TACADA
    public bool guitarrapodeagredir;
    public static float ballPowerImpulse;
    public float ballPowerImpulseMax;
    public float rotTacada = 300;
    public float CDtacada;
    public float CDtacadaMax;
    public bool solteiOclick;
    // guitarras 
    public bool podeMultiplicar;
    public bool guitarDouble;
    public bool guitarDmg;
    public bool guitarNotes;
    public float ballSpawncd;

    // Input
    public Touch touchPhases;
    //Rock Mode
    [SerializeField]
    public static int rockModeCount;
    [SerializeField]
    public static int rockModeCountMax;
    public bool leaf;
    public bool verificarROckmodecount;
    public float tempoSairRcok = 10;

    public static bool ativandoAura;
    public List<GameObject> listPlayer = new List<GameObject>();
    void Start()
    {
       

        Ballsapwn.ball_SpawnCD = 5.5f;
        ballSpawncd = Ballsapwn.ball_SpawnCD;
        CDtacadaMax = CDtacada;
       
        // arrow reticle
        arrowBG.rectTransform.position = startPosRef.position;
        arrowBGs.rectTransform.position = startpositionUIangle.position;

        podeMultiplicar = true;
        refsp = Instantiate(part, new Vector2(transform.position.x + 0.5f, transform.position.y - 1), part.transform.rotation) as GameObject;
        rig.SetBool("parado", true);
        switch (PlayerPrefs.GetString("GuitarUsando"))
        {
            case "base":
                guitarDmg = false;
                guitarNotes = false;
                guitarDouble = false;
                break;
            case "dmg":
                guitarDmg = true;
                guitarNotes = false;
                guitarDouble = false;
                break;
            case "double":
                guitarDmg = false;
                guitarNotes = false;
                guitarDouble = true;
                break;
            case "note":
                guitarDmg = false;
                guitarNotes = true;
                guitarDouble = false;
                break;

        }
        //  danoTacadaa = ballPowerImpulse / 2;
        ballPowerImpulse = GameManager.instanceGameManager.power;
        if (guitarDmg)
        {
            ballPowerImpulse *= 2;
        }
        ballPowerImpulseMax = ballPowerImpulse;
    }
    void Update()
    {
        if (ativandoAura)
        {
               sayajin.Play();
            ativandoAura = false;
        }
       

        if (!GameManager.instanceGameManager.gamePause)
        {
            if (verificarROckmodecount)
            {
                StartCoroutine("CDRockTime");   
            }
        }
        SetaRotate();
        ImpulseProjectsAlternative();
       // ImpulseProjects();
    }
    void FixedUpdate()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ball"))
        {
            col.gameObject.GetComponent<Rigidbody2D>().drag = 0;
            listPlayer.Add(col.gameObject);
            if (solteiOclick)
            {
                PegandoRefDasball();
            }
        }
        if (col.gameObject.CompareTag("inimigo"))
        {
            rig.SetBool("parado", false);
            rig.SetBool("batendo", false);
            rig.SetBool("morrendo", true);
            GameManager.instanceGameManager.gameLose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            listPlayer.Remove(collision.gameObject);

        }
    }
    // DIREÇÃO QUE A BOLA VAI IR
    void SetaRotate()
    {
        x = ballPowerImpulse * Mathf.Cos(arrowZRotate * Mathf.Deg2Rad);//Força do chute e Calculo para angulo do chute
        y = ballPowerImpulse * Mathf.Sin(arrowZRotate * Mathf.Deg2Rad);
        arrowBG.rectTransform.eulerAngles = new Vector3(0, 0, arrowZRotate);// Adiciona rotação a SETA
        arrowBGs.rectTransform.localPosition = new Vector3(0, arrowY);
        arrowY += rotvel / 2 * Time.deltaTime;
        arrowZRotate += rotvel * Time.deltaTime;
        if (arrowZRotate >= 90)
        {
            rotvel = -200;
        }
        else if (arrowZRotate <= -90)
        {
            rotvel = 200;
        }
    }
    // Inputs
   /* void ImpulseProjects()
    {
        if (Input.GetMouseButtonDown(0) && guitarrapodeagredir && !EventSystem.current.IsPointerOverGameObject())
        {
            rotvelSave = rotvel;
        }
        if (Input.GetMouseButton(0) && guitarrapodeagredir && !EventSystem.current.IsPointerOverGameObject())
        {
            rig.SetBool("parado", false);
            rig.SetBool("segurandodano", true);
            rotvel = 0;
            if (ballPowerImpulse <= 1.5 * ballPowerImpulseMax)
            {
                ballPowerImpulse += ballPowerImpulse / 10 * Time.deltaTime;
                Hud.instance.ballPowerImpulse.text = ballPowerImpulse.ToString();
            }
        }
        if (Input.GetMouseButtonUp(0) && guitarrapodeagredir && !EventSystem.current.IsPointerOverGameObject())  // ao soltar o o click adiciona força a bola
        {
            trailrender.emitting = true;
            solteiOclick = true;
            rig.SetBool("segurandodano", false);
            rig.SetBool("batendo", true);
            guitarrapodeagredir = false;
            StartCoroutine("CDTacada");
            StartCoroutine("Stoprot");
            StartCoroutine("StopBatendo");
        }
    }*/
   void ImpulseProjectsAlternative()
    {

        if (Input.touchCount > 0 && guitarrapodeagredir )
        {

            touchPhases = Input.GetTouch(0);
          switch (touchPhases.phase)
            {
                case TouchPhase.Began:
                    rotvelSave = rotvel;
                    break;
                case TouchPhase.Stationary:

                    rig.SetBool("batendo", false);
                    rig.SetBool("parado", false);
                    rig.SetBool("segurandodano", true);
                    rotvel = 0;
                    if (ballPowerImpulse <= 1.5 * ballPowerImpulseMax)
                    {
                        ballPowerImpulse += ballPowerImpulse / 10 * Time.deltaTime;
                        Hud.instance.ballPowerImpulse.text = ballPowerImpulse.ToString();
                    }
                    break;
                case TouchPhase.Ended:
                    trailrender.emitting = true;
                    solteiOclick = true;
                    rig.SetBool("batendo", true);
                    rig.SetBool("parado", false);
                    rig.SetBool("segurandodano", false);
                    guitarrapodeagredir = false;
                    StartCoroutine("CDTacada");
                    StartCoroutine("Stoprot");
                    StartCoroutine("StopBatendo");
                    break;
                case TouchPhase.Canceled:
                    trailrender.emitting = true;
                    solteiOclick = true;
                    rig.SetBool("batendo", true);
                    rig.SetBool("parado", false);
                    rig.SetBool("segurandodano", false);
                    guitarrapodeagredir = false;
                    StartCoroutine("CDTacada");
                    StartCoroutine("Stoprot");
                    StartCoroutine("StopBatendo");
                    break;
            }
        }
    }
    //
    // chutando a bola literalmente, adicionando dano multiplicando
    //
    void PegandoRefDasball()
    {
        foreach (GameObject player in listPlayer)
        {
            if (player == null)
            {
                listPlayer.Remove(player);
                break;
            }
            else if (player != null)
            {
                player.GetComponent<Rigidbody2D>().drag = 0;
                if (guitarNotes)
                {
                    refsp.GetComponent<ParticleSystem>().Play(true);
                }
                if (guitarDouble)
                {
                    if (podeMultiplicar)
                    {
                        GameObject a = Instantiate(player, new Vector2(player.transform.position.x, player.transform.position.y + 1.5f), player.transform.rotation);
                        a.GetComponent<Rigidbody2D>().drag = 0;
                        podeMultiplicar = false;
                    }
                }
                if (!player.GetComponent<Ball>().jaFuiAcertado || player.GetComponent<Rigidbody2D>().velocity.x < 0 )
                {
                    player.GetComponent<Ball>().jaFuiAcertado = true;
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, -y+0.4f), ForceMode2D.Force);
                    AudioManager.audioManager.SoundEffect(0);
                }
            }
        }
    }
    public   void RockMode()
    {
        if (rockModeCount >= 1)
        {

            AudioManager.audioManager.guitarBGAS.volume = 1; 
        }
    }
    public void DesativaANim()
    {
        rig.SetBool("batendo", false);
        rig.SetBool("parado", true);
        rig.SetBool("segurandodano", false);

    }
    IEnumerator StopBatendo()
    {
        yield return new WaitForSeconds(0.20f);
        rig.SetBool("batendo", false);
        rig.SetBool("parado", true);
        rig.SetBool("segurandodano", false);

        ballPowerImpulse = ballPowerImpulseMax;
        Hud.instance.ballPowerImpulse.text = ballPowerImpulse.ToString();

    }
    IEnumerator Stoprot()
    {
        yield return new WaitForSeconds(1f);
        rotvel = rotvelSave;
    }
    IEnumerator CDTacada()
    {
        yield return new WaitForSeconds(CDtacada);
        guitarrapodeagredir = true;
        solteiOclick = false;
        podeMultiplicar = true;
        trailrender.emitting = false;
    }
     IEnumerator CDRockTime()
    {
        verificarROckmodecount = false;
        rockModeCountMax = rockModeCount;

        yield return new WaitForSeconds(tempoSairRcok);
        print("max" + rockModeCountMax + " " + "atual" + rockModeCount);
        if (rockModeCountMax == rockModeCount)
        {
            sayajin.Stop();
            Ballsapwn.ball_SpawnCD = ballSpawncd;
            rockModeCount = 0;
            rockModeCountMax = 0;
            AudioManager.audioManager.guitarBGAS.volume = 0;
        }
        verificarROckmodecount = true;
    }
   
        
       
    
}

