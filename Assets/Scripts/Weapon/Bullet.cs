using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float speed = 10f;
    //public GameObject effectsPrefab;
    public Transform line;

    public GameObject bulletPrefab;
    public Transform shotOrigin;
    private Rigidbody rigid;

    void Awake()
    {
        // Get component on awake so we don't miss it if it starts disabled
        rigid = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision col)
    {
        // Get contact point from collision
        ContactPoint contact = col.contacts[0];

        Enemy enemy = col.collider.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.TakeDamage(damage);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }

    public void Fire(Vector3 lineOrigin, Vector3 direction)
    {
        // Add an instant force to the bullet
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        // Set the line's origin (different from the bullet's starting position)
        line.transform.position = lineOrigin;
    }
}