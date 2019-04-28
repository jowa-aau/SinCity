using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Framework;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntGenerator : Singleton<AntGenerator>
{
    [SerializeField] private List<GameObject> antPrefabs;


    private AntGenerator() {}

    public void Init(List<GameObject> prefabs)
    {
        this.antPrefabs = prefabs;
    }


    public void GenerateAnts(float x, float y , int count)
    {
        for (int i = 0; i < count; i++) {
            int randomIndex = Random.Range(0, antPrefabs.Count);
            GameObject prefab = antPrefabs[randomIndex];
               
            GenerateAnt(prefab,x,y);
        }
           
    }

    public void GenerateAnt(GameObject antPrefab, float x, float y)
    {
        Vector3 position = new Vector3(x, y, 0);
        Instantiate(antPrefab, position, Quaternion.identity);
    }
   
}
