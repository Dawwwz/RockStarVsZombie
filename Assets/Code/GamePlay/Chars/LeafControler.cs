using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafControler : MonoBehaviour
{
    [SerializeField] private SpawnController spawnControler;
    [SerializeField] private LevelManager levelManager;
    [Header("LeafSystem")]
    [SerializeField] private bool leafEnemy;
    [SerializeField] private bool leafDog;
    [SerializeField] private bool leafRockStar;
    [SerializeField] private bool leafVoid;

    [SerializeField] private bool leafCanSpawn;
    [SerializeField] private bool leafCatch;
    [SerializeField] private string leafLevel;
    [SerializeField] private bool leafBool;
    [SerializeField] private int leafChanceSpawn;
    [SerializeField] private int leaf;
    [SerializeField] private GameObject[] leafs;

    // Start is called before the first frame update
    private void Awake()
    {
        spawnControler = FindObjectOfType<SpawnController>();
        levelManager = FindObjectOfType<LevelManager>();

        leafVoid = true;
    }
    private void Start()
    {

    }
    public void Set_Spawn_Leaf(Transform transform)
    {
         spawnControler.Set_Select_GameObject(leafs, leaf,leaf, transform.position, 1);
      
    }
    public void Set_Leaf_Spawn()
    {
        // systema leaf
        if (PlayerPrefs.GetInt("Level" + levelManager.scenaAtualInt) == 0 && leafVoid && Get_Leaf_can_Spawn())
        {         
            leafChanceSpawn = Random.Range(0, 2);
            if(leafChanceSpawn == 1)
            {
                Set_Ho_Get_leaf(false, false, true, false);
                for (int i = 0; i < leafs.Length; i++)
                {
                    if (levelManager.scenaAtualString == "Level" + i)
                    {

                        leaf = i;  // recebe o gameobject  indicado para cada faze

                    }
                }
            }
           
        }
    }
    public void Set_Ho_Get_leaf(bool rockStar,bool dog,bool enemy,bool voiid)
    {
        leafEnemy = enemy;
        leafDog = dog;
        leafEnemy = enemy;
        leafVoid = voiid;
    }
    public void Set_leaf_Can_Spawn(bool leaf)
    {
        leafCanSpawn = leaf;
    }
    public void Set_leaf_Level(string  levelLeaf)
    {
        leafLevel = levelLeaf;
    }
    public int Get_Leaf_Chance_Spawn()
    {
        return leafChanceSpawn;
    }
    public bool Get_Leaf_can_Spawn()
    {
        return leafCanSpawn;
    }
    public bool Get_Leaf_Catch()
    {
        return leafCatch;
    }
    public void UpdateLeaf()
    {
        if (leafRockStar)
        {
            for(int i = 0; i < levelManager.levelAtual.Length; i++)
            {
            
                if (leafLevel == "Level"+i)
                {
                    PlayerPrefs.SetInt("Level"+i, 1);
                }
            }   
        }
    }
    public bool Get_Who_Leaf()
    {
        if (leafRockStar)
        {
            return leafRockStar;
        }
        else if(leafDog)
        {
            return leafDog;
        }
        else if (leafEnemy)
        {
            return leafEnemy;
        }
        else
        {
            return leafVoid;
        }
    }

}
