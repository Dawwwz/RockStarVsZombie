using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particleee : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {

            other.gameObject.GetComponent<Inimigo>().Set_Damage(player.Get_HitPower() / 2);
            other.gameObject.GetComponent<Inimigo>().Set_Life_Bar_Update();
        }
    }
}
