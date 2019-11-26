using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    private Quaternion startRotation;
    private Quaternion newRotation;

    [SerializeField] private int speedX = 3;
    [SerializeField] private int speedY = 3;
    [SerializeField] private int maxDistanceX = 1;
    [SerializeField] private int maxDistanceY = 1;

    void Start()
    {
        startRotation = transform.rotation;
        newRotation = transform.rotation;
    }

    void Update()
    {
        // X
        newRotation.x = startRotation.x + (maxDistanceX * Mathf.Sin(Time.time * speedX));
        transform.rotation = newRotation;
        // Y
        newRotation.y = startRotation.y + (maxDistanceY * Mathf.Sin(Time.time * speedY));
        transform.rotation = newRotation;
    }
}