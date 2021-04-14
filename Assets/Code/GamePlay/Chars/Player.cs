using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Player : Character
{
    
    [Header("HitAserAjustado")]
    [SerializeField] private float ballPowerImpulseMax;

    [Header("Fases do Input")]
    public Touch touchPhases;
    [SerializeField] private bool cliquei;
    [SerializeField] private bool segurandoclick;
    [SerializeField] private bool solteiOclick;

    [Header("skillsDoPLayer")]
    [SerializeField] private bool podeMultiplicar;
    [SerializeField] private bool guitarDouble;
    [SerializeField] private bool guitarDmg;
    [SerializeField] private bool guitarNotes;

    [Header("ballSpawnCd")]
    [SerializeField] private float ballSpawncd;

    [SerializeField] private SpriteRenderer getSprite;
    [SerializeField] private Sprite[] sprites;
    [Header("Pegando_Referencia_Das_Bolas_Ao_Colidir")]
    [SerializeField] private List<GameObject> listPlayer = new List<GameObject>();


    void Start()
    {
        hud.SetTxtBallPOwer(hitPower.ToString());
        rigAnime = GetComponent<Animator>();
        RigAnimation(true, false, false, false, false); // COMEÇA COM ANIMAÇÃO IDDLE
        //ballPowerImpulse = GameManager.instanceGameManager.power; //RECEBE A FORÇA DO HIT
        switch (PlayerPrefs.GetString("GuitarUsando")) //SYSTEMA PARA SELECIONAR GUITARRA
        {
            case "baseguitar":
                Set_Guitar_In_Use(false, false, false);
                getSprite.sprite = sprites[0];

                break;
            case "dmg":
                Set_Guitar_In_Use(true, false, false);
                getSprite.sprite = sprites[1];

                if (guitarDmg) // DOBRA O DANO DO HIT (CASO A GUITARRA DE DOBRAR O DANO ESTEJA SELECIONADA)         
                {
                    hitPower *= 2;
                }
                break;
            case "double":
                Set_Guitar_In_Use(false, true, false);
                getSprite.sprite = sprites[2];
                break;
            case "note":
                Set_Guitar_In_Use(false, false, true);
                getSprite.sprite = sprites[3];
                break;

        }
        ballPowerImpulseMax = hitPower; // SALVA A FORÇA DO HIT PARA VOLTAR DEPOIS
    }
    private void Update()
    {
        SetInputs();
        //Contador();
       
    }
    public void SetInputs()
    {
        if (Input.GetMouseButtonDown(0) && hitBool && !cliquei && EventSystem.current.currentSelectedGameObject == null)
        {
            RigAnimation(false, false, false, true, false);

            hitTarget.SetSaveRotate();
            hitTarget.SetStopRotate();
            hud.SetTxtBallPOwer(hitPower.ToString());
            particle.trailrender.emitting = true;
            cliquei = true;
        }
        if (Input.GetMouseButton(0) && hitBool && cliquei && EventSystem.current.currentSelectedGameObject == null)
        {
            hud.SetTxtBallPOwer(hitPower.ToString());
            segurandoclick = true;
            RigAnimation(false, false, false, true, false);
            if (hitPower <= 1.6 * ballPowerImpulseMax)
            {
                hitPower += hitPower / 10 * Time.deltaTime;
                hud.SetTxtBallPOwer(hitPower.ToString());
            }
        }
        if (Input.GetMouseButtonUp(0) && hitBool && segurandoclick )
        {

            solteiOclick = true;
            RigAnimation(false, false, true, false, false);
            hitBool = false;
        }
    }// if > && hitBool && !EventSystem.current.IsPointerOverGameObject()
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            RigAnimation(false, false, false, false, true);
            Time.timeScale = 0;
            levelManager.Set_Lose_Game(true);
            levelManager.LoseGame();
            
            // GameManager.instanceGameManager.gameLose = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
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

    }
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
                    particle.refsp.GetComponent<ParticleSystem>().Play(true);
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
                if (!player.GetComponent<Ball>().jaFuiAcertado || player.GetComponent<Rigidbody2D>().velocity.x < 0)
                {

                    player.GetComponent<Ball>().sochama();
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(hitTarget.GetAtributeX(), -hitTarget.GetAtributeY() + 0.19f), ForceMode2D.Force);
                    // AudioManager.audioManager.SoundEffect(0);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            listPlayer.Remove(collision.gameObject);

        }
    }
    public void SetPararHitAnimation()
    {
        RigAnimation(true, false, false, false, false);
        hitTarget.SetPlayRotate();
        hitPower = ballPowerImpulseMax;
        hud.SetTxtBallPOwer(hitPower.ToString());
        particle.trailrender.emitting = false;
        podeMultiplicar = true;
        solteiOclick = false;
        cliquei = false;
        segurandoclick = false;
        hitBool = true;
    }
    public void Set_Guitar_In_Use(bool dmgGuitar, bool doubleeGuitar, bool notesGuitar)
    {
        guitarDmg = dmgGuitar;
        guitarDouble = doubleeGuitar;
        guitarNotes = notesGuitar;
    }
    public void Set_Sayajin_Aura()
    {
        particle.Set_Sayajin_Aura();
    }

    public void Set_Sayajin_Aura_off()
    {
        particle.Set_Sayajin_Aura_off();
    }

    public void Set_Diminuir_Spawn_Bola()
    {
        spawnController.Set_Diminuir_Spawn_Bola();
    }
    public void Set_Aumentar_Tempo_Spawn_Bola()
    {
        spawnController.Set_Aumentar_Tempo_Spawn_Bola();
    }
}
