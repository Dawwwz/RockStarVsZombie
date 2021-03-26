using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Particlee : MonoBehaviour
{
    public GameObject Sayajin;
    public GameObject refsp;
    public GameObject part;
    public TrailRenderer trailrender;
    private void Start()
    {
        refsp = Instantiate(part, new Vector2(transform.position.x + 0.5f, transform.position.y - 1), part.transform.rotation) as GameObject;
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {

            other.gameObject.GetComponent<Inimigo>().Set_Damage(Player.ballPowerImpulse / 4);
            other.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
        }
    }
    public void Set_Sayajin_Aura()
    {
        Sayajin.SetActive(true);
    }
    public void Set_Sayajin_Aura_off()
    {
        Sayajin.SetActive(false);
    }


}
