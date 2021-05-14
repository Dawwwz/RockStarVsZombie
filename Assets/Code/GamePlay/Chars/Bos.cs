using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bos : Inimigo
{
    // Start is called before the first frame update
    [SerializeField] private SpawnControllerEnemy spawnZombie;
    void Start()
    {
        spawnZombie = FindObjectOfType<SpawnControllerEnemy>();
        leafControler.Set_Leaf_Spawn();

        lifeBar.SetLifeBarSpawn();
        lifeBar.SetLifeBarTransform(lifeBarPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        if (spawnZombie.Get_SpawnSituation())
        {
            
            StartCoroutine(lala());
        }
        if (spawnZombie.Get_SpawnSituationn())
        {
            StartCoroutine(lala());

        }

        Vida();
        if (lifeBar.Get_Life_Bar_GO() != null)
        {
            lifeBar.SetLifeBarTransform(lifeBarPos);
        }
    }
    IEnumerator lala()
    {
        RigAnimationn(false, true);
        yield return new WaitForSeconds(2);
        RigAnimationn(true,false );
    }
}
