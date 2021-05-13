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

        if (collision.CompareTag("inimigo") )
        {
            if (collision.gameObject.GetComponent<CircleCollider2D>() != null ) 
            {
                zombie.Add(collision.transform.root.gameObject);
                // collision.transform.root.GetComponent<Inimigo>().Set_Velocity(false);
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
                           
                            zomb.GetComponent<Inimigo>().Set_Damage(danoTacada / 4);
                            collision.transform.root.GetComponent<Inimigo>().Set_Velocity(false);
                            zomb.transform.root.GetComponent<Inimigo>().Set_VelocityFloat(0);
                            zomb.transform.root.GetComponent<Inimigo>().State(false, true);
                            zomb.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezeAll;
                            zomb.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                            zomb.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
                            zomb.GetComponent<SpriteRenderer>().color = Color.blue;
                           
                        }
                            else
                            {
                            collision.transform.root.GetComponent<Inimigo>().VelRechargeTimes(0.7f);
                            zomb.GetComponent<Inimigo>().Set_Damage(danoTacada / 2.5f);
                            }

                            if (zomb.GetComponent<Inimigo>().Get_Life_Bar_GO() != null)
                            {
                                 zomb.GetComponent<Inimigo>().Set_Life_Bar_Update();
                            }
                        }
                    }
                    if (GetComponent<PointEffector2D>() != null)
                    {

                        GetComponent<PointEffector2D>().enabled = true;
                    }
            }
            GetComponent<CircleCollider2D>().enabled = false;
            
            Destroy(gameObject,1f);
            
        }
    }
}
