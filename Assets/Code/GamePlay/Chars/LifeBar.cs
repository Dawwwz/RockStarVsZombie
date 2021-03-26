using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{
    [SerializeField] private Canvas hud;
    [SerializeField] private GameObject lifeBarPrefab;
    [SerializeField] private GameObject lifeBarGameObject;

    private bool leaf;
    // Start is called before the first frame update
    void Start()
    {

        hud = GameObject.FindGameObjectWithTag("Canvas_WP").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void SetLifeBarSpawn()
    {
        GameObject aa = GameObject.Find("CanvasWS_Hud");
        hud = aa.GetComponent<Canvas>();
        GameObject a = Instantiate(lifeBarPrefab) as GameObject;
        lifeBarGameObject = a;
        lifeBarGameObject.transform.SetParent(hud.transform, true);
        
    }
    public GameObject Get_Life_Bar_GO()
    {
        return lifeBarGameObject;
    }
    public void Set_Life_Bar_Update(float charLife,float charLifeMax)
    {
        if(lifeBarGameObject != null)
        {
         lifeBarGameObject.GetComponent<Image>().fillAmount = charLife / charLifeMax;         
        }
    }
    public void SetLifeBarTransform(Transform lifeBarTransform)
    {
         this.lifeBarGameObject.transform.position = lifeBarTransform.position; 
    }
}
