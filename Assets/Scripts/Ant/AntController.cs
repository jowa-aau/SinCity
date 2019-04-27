using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AntController : MonoBehaviour
{
    [SerializeField] private List<Sprite> spitesList;
    private void Start()
    {
        // ant generator
        AntGenerator generator = new AntGenerator(100,spitesList);
        generator.GenerateAnt(0, 0);
    }

}
