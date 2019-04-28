using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillTimer : MonoBehaviour
{
    [SerializeField] private float waitTime = 1.0f;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime) {
            Destroy(this.gameObject);
            timer = 0.0f;
        }
    }
}
