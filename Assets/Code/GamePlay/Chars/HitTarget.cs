using UnityEngine;
using UnityEngine.UI;

public class HitTarget : MonoBehaviour
{
    [SerializeField] private Hud hud;
    [SerializeField] private float rotateVelocity = 200;
    [SerializeField] private float rotateVelocitySave;
    [SerializeField] private float arrowZRotate, arrowY;
    [SerializeField] private Image arrowBG, arrowBGs;
    [SerializeField] private Transform startPosRef, startpositionUIangle;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float rot;
    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<Hud>();
        arrowBG = hud.Get_HItTarget_ArrowBG();
        arrowBGs = hud.Get_HItTarget_ArrowBGs();
    }

    // Update is called once per frame
    void Update()
    {
        SetaRotate();
    }
    void SetaRotate()
    {
        x = Player.ballPowerImpulse * Mathf.Cos(arrowZRotate * Mathf.Deg2Rad);//Força do chute e Calculo para angulo do chute
        y = Player.ballPowerImpulse * Mathf.Sin(arrowZRotate * Mathf.Deg2Rad);
        arrowBG.rectTransform.eulerAngles = new Vector3(0, 0, arrowZRotate);// Adiciona rotação a SETA
        arrowBGs.rectTransform.localPosition = new Vector3(0, arrowY);
        arrowY += rotateVelocity / 2 * Time.deltaTime;
        arrowZRotate += rotateVelocity * Time.deltaTime;
        if (arrowZRotate >= 90)
        {
            rotateVelocity = -200;
        }
        else if (arrowZRotate <= -90)
        {
            rotateVelocity = 200;
        }
    }

    //Getters
    public float GetAtributeX()
    {
        return x;
    }
    public float GetAtributeY()
    {
        return y;
    }
    public float GetAtributeRotateVelocity()
    {
        return this.rotateVelocity;
    }
    public float GetAtributeRotateVelocitySave()
    {
        return this.rotateVelocitySave;
    }
    public float GetAtributeArrowZRotate()
    {
        return this.arrowZRotate;
    }
    //Setters
    public void SetSaveRotate()
    {
        this.rotateVelocitySave = this.rotateVelocity;
    }
    public void SetStopRotate()
    {
        this.rotateVelocity = 0;
    }
    public void SetPlayRotate()
    {
        this.rotateVelocity = this.rotateVelocitySave;
    }
}
