using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int maxReserve = 500, maxClip = 30;
    public float spread = 2f, recoil = 1f, range = 10f, shootRate = .2f;
    public Transform shotOrigin;
    public GameObject bulletPrefab;
    public bool canShoot = false;

    private int currentReserve = 0, currentClip = 0;
    private float shootTimer = 0;

    void Start()
    {
        Reload();
    }

    void Update()
    {
        // Increase the shoot timer
        shootTimer += Time.deltaTime;

        // Check if shoot timer reaches the rate
        if (shootTimer >= shootRate)
        {
            // Can shoot!
            canShoot = true;
        }

    }

    void Reload()
    {
        // If there are bullets left in reserve
        if (currentReserve > 0)
        {
            // If there is enough bullets in reserve to fill a clip
            if (currentReserve >= maxClip)
            {
                // Reduce the clip size by the offset from the current clip to max Clip
                int offset = maxClip - currentClip;
                currentReserve -= offset;
            }
            // If clip is below max clip
            if (currentClip < maxClip)
            {
                int tempMag = currentReserve;
                currentClip = tempMag;
                currentReserve -= tempMag;
            }
        }
    }

    public void Shoot()
    {
        // Reduce clip size
        currentClip--;
        // Reset shoot timer
        shootTimer = 0;
        // Reset canShoot
        canShoot = false;
        // Get origin + direction of fire
        Camera attachedCamera = Camera.main;
        Transform camTransform = attachedCamera.transform;
        Vector3 lineOrigin = shotOrigin.position;
        Vector3 direction = camTransform.forward;
        // Shoot bullet
        GameObject clone = Instantiate(bulletPrefab, camTransform.position, camTransform.rotation);
        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.Fire(lineOrigin, direction);

        Invoke("ShootBackwards", 1f);
    }

    public void ShootBackwards()
    {
        // Get origin + direction of fire
        Camera attachedCamera = Camera.main;
        Transform camTransform = attachedCamera.transform;
        Vector3 lineOrigin = shotOrigin.position;

        Vector3 direction = camTransform.forward;
        direction = new Vector3(0, 0, .2f);

        //Vector3 rot = camTransform.rotation.eulerAngles;
        //rot = new Vector3(rot.x + 180, rot.y, rot.z);

        // Shoot bullet
        GameObject clone = Instantiate(bulletPrefab, camTransform.position, camTransform.rotation);

        //GameObject clone = Instantiate(bulletPrefab, camTransform.position, camTransform.rotation = Quaternion.Euler(rot));

        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.Fire(lineOrigin, -direction);
    }
}