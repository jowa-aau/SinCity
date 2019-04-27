using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntGenerator 
{
    public static int ants = 0;
    public int maxAnts = 100;
    [SerializeField] private List<Sprite> spitesList;
    private List<GameObject> antsGameObject;
    

    public AntGenerator(int maxAnts, List<Sprite> spitesList)
    {
        antsGameObject = new List<GameObject>();
        if (maxAnts <= 0)
        {
            this.maxAnts = 100;
        }else
        {
            this.maxAnts = maxAnts;
        }

        this.spitesList = spitesList;
    }


    public void GenerateAnt(float x, float y )
    {
        /*
           int randomIndex = Random.Range(0, spitesList.Count);
           Sprite sprite = spitesList[randomIndex];
               
           GenerateAnt(sprite,x,y);
         */
        
        // testing loop
        for (int i = 0; i < maxAnts; i++)
        {
           // Texture2D antTexture = Resources.Load("Assets/Sprites/Streets/Ant01.png") as Texture2D;
           int randomIndex = Random.Range(0, spitesList.Count);
           Sprite sprite = spitesList[randomIndex];
               
           GenerateAnt(sprite,x,y);
        }

    }

    public void GenerateAnt(Sprite antSprite, float x, float y)
    {

        if (ants >= maxAnts)
        {
            return;
        }
        GameObject go = new GameObject("ant_" + ants);
       
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        
        Vector2 position = new Vector2( x,y);

        renderer.sprite = antSprite;
        
        renderer.sortingLayerName = "Ants";

        go.AddComponent<AntBehaviorController>();
        
        antsGameObject.Add(go);
        ants += 1;

    }

    public void SetMaxAnts(int maxAnts)
    {
        this.maxAnts = maxAnts;
    }
   
}
