using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Particlee : MonoBehaviour
{
 
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {

            other.gameObject.GetComponent<Inimigo>().vida -= Player.ballPowerImpulse / 4 ;
            other.gameObject.GetComponent<Inimigo>().lifeBartrue.GetComponent<Image>().fillAmount = other.gameObject.GetComponent<Inimigo>().vida / other.gameObject.GetComponent<Inimigo>().vidaMax;
        }
    }
}
