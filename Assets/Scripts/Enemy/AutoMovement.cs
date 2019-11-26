using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 newPosition;

    [SerializeField] private int speedX = 3;
    [SerializeField] private int speedY = 3;
    [SerializeField] private int maxDistanceX = 1;
    [SerializeField] private int maxDistanceY = 1;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        // X
        newPosition.x = startPosition.x + (maxDistanceX * Mathf.Sin(Time.time * speedX));
        transform.position = newPosition;
        // Y
        newPosition.y = startPosition.y + (maxDistanceY * Mathf.Sin(Time.time * speedY));
        transform.position = newPosition;
    }
}