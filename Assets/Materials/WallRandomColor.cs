using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandomColor : MonoBehaviour
{
    public float timeToChange = 0.1f;
    private float timeSinceChange = 0;

    public Color[] colors;

    void Update()
    {
        timeSinceChange += Time.deltaTime;

        if(timeSinceChange >= timeToChange)
        {
            gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];

            timeSinceChange = 0f;
        }
    }
}
