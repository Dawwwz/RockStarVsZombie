using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{

    [Header("System's to help")]
    [SerializeField] protected SpawnController spawnController;
    [SerializeField] protected Hud hudd;
    [SerializeField] protected RockMode rockMode;
    [SerializeField] protected AudioManager audioScript;

    public Canvas hud;
    public GameObject dmgPref;
    public GameObject dmgTrue;
    public Transform  dmgPos;

    public bool jaFuiAcertado;
    public bool podeDarDano = true;

    public float frequenciaDmg;
    public float deathTime;
    public float danoTacada;
    public float danotacaday;
    public void Awake()
    {
        Set_Search_For_Refs(); 
    }
    private void LateUpdate()
    {
        if (transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
        
    }
    public  void Start()
    {
        
        // life bar
        GameObject aa = GameObject.Find("CanvasWS_Hud");
        hud = aa.GetComponent<Canvas>();
        if (gameObject.transform.position.y > 4)
        {

            gameObject.GetComponent<Rigidbody2D>().drag = 3;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().drag = 0;
        }
    }
   public void Update()
    {
        danoTacada = gameObject.GetComponent<Rigidbody2D>().velocity.x/6;
        danotacaday = gameObject.GetComponent<Rigidbody2D>().velocity.y / 6;
    }
    // COLISÃO COM OS OBJETOS DO GAME
    public void FixedUpdate()
    {

    }

    public void dmgHUD()
    {

        if (danoTacada < 0 )
        {
            danoTacada = danoTacada * -1;
           
        }
        if (danotacaday < 0)
        {
            danotacaday = danotacaday * -1;

        }
        if(danoTacada < danotacaday)
        {
          danoTacada = danotacaday;
        }
        GameObject aaa = Instantiate(dmgPref) as GameObject;
        dmgTrue = aaa;
        dmgTrue.transform.SetParent(hud.transform, true);
        dmgTrue.transform.position = dmgPos.position;
        dmgTrue.GetComponent<Text>().text = Math.Round(danoTacada,1).ToString(); 
        Destroy(gameObject, deathTime);
        
      //  AudioManager.audioManager.SoundEffect(2);
    }
    protected IEnumerator CD()
    {
        podeDarDano = false;
        yield return new WaitForSeconds(frequenciaDmg);
        
        podeDarDano = true;
        
    }
    IEnumerator PossoSerAcertadoDnvEm()
    {
        jaFuiAcertado = true;
        yield return new WaitForSeconds(2);

        jaFuiAcertado = false; 
    }
    public void sochama()
    {
        StartCoroutine(PossoSerAcertadoDnvEm());
    }
    public void Set_Search_For_Refs()
    {
        audioScript = FindObjectOfType<AudioManager>();
        spawnController = FindObjectOfType<SpawnController>(); 
        rockMode = FindObjectOfType<RockMode>();
        hudd = FindObjectOfType<Hud>();
    }
}
