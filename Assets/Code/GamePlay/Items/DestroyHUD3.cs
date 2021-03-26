using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyHUD3 : MonoBehaviour
{
    public float danoTacada;
    public List<GameObject> zombie = new List<GameObject>();
   
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("inimigo"))
        {
            if (collision.gameObject.GetComponent<CapsuleCollider2D>())
            {
                zombie.Add(collision.transform.root.gameObject);
                collision.transform.root.GetComponent<Inimigo>().Set_Velocity(false);
                foreach (GameObject zomb in zombie)
                    {
                        if (zomb == null)
                        {
                            this.zombie.Remove(zomb);
                            break;
                        }
                        if (zomb != null && zomb.GetComponent<Inimigo>().Get_Life() > 0)
                        {
                            if (GetComponent<PointEffector2D>() == null)
                            {
                                zomb.GetComponent<Inimigo>().Set_Velocity(false);
                                zomb.GetComponent<Inimigo>().Set_Damage(danoTacada / 4);
                            }
                            else
                            {
                            zomb.GetComponent<Inimigo>().Set_Damage(danoTacada / 2.5f);
                            }
                            if (zomb.GetComponent<Inimigo>().Get_Life_Bar_GO() != null)
                            {
                                 zomb.GetComponent<Inimigo>().Set_Life_Bar_Update();
                            }
                        }
                    }
            }
                if (GetComponent<PointEffector2D>() != null)
                {
                GetComponent<PointEffector2D>().enabled = true;
                }
                GetComponent<CircleCollider2D>().enabled = false;
                Destroy(gameObject,0.5f);
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("inimigo"))
        {
            zombie.Remove(col.gameObject);
        }
    }
}
