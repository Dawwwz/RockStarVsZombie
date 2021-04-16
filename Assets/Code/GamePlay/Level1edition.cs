using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1edition : MonoBehaviour
{
   [SerializeField] private SpawnControllerEnemy spawn;
   [SerializeField] private Inimigo esse;
   [SerializeField] private LevelManager level;
   [SerializeField] private bool spawnhu;
    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        spawn = FindObjectOfType<SpawnControllerEnemy>();
        esse = GetComponent<Inimigo>();
    }
    void Update()
    {
        Level1Free();
    }
    public void Level1Free()
    {   
        if (esse.Get_Life() <= 0)
        {
            spawnhu = true;
            level.levelJaFoi = spawnhu;
            spawn.leveljafoi = spawnhu;
        }
    }
}
