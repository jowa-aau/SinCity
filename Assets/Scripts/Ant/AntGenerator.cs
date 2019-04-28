using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntGenerator 
{
    [SerializeField] private List<Sprite> spitesList;
    private List<GameObject> antsGameObject;
    

    public AntGenerator(List<Sprite> spitesList)
    {
        antsGameObject = new List<GameObject>();
        this.spitesList = spitesList;
    }


    public void GenerateAnts(float x, float y , int count)
    {
        for (int i = 0; i < count; i++) {
            int randomIndex = Random.Range(0, spitesList.Count);
            Sprite sprite = spitesList[randomIndex];
               
            GenerateAnt(sprite,x,y);
        }
           
    }

    public void GenerateAnt(Sprite antSprite, float x, float y)
    {

        GameObject go = new GameObject("ant");
       
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        
        Vector2 position = new Vector2( x,y);

        renderer.sprite = antSprite;
        
        renderer.sortingLayerName = "Ants";

        go.AddComponent<AntBehaviorController>();
        
        antsGameObject.Add(go);
    }
   
}
