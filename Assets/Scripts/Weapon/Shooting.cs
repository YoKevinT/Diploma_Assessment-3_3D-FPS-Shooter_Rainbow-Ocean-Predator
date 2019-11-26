using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Weapon currentWeapon;

    // Update is called once per frame
    void Update()
    {
        // The is a current Weapon
        if (currentWeapon)
        {
            // Is the fire button down?
            if(Input.GetButtonDown("Fire1"))
            {
                if (currentWeapon.canShoot)
                {
                    currentWeapon.Shoot();
                }
            }
        }
    }
}
