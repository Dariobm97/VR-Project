using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLeft : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
    public GameObject controllerMesh;
    public float bulletLifeSpawn = 5f;
    public float bulletVelocity = 30;
    public AudioClip fireSound;

    void Update()
    {
        // Check if the object this script is attached to is being grabbed by the player.
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
            controllerMesh.SetActive(false);
            // Check if the player's primary hand trigger (usually the index finger) is being pressed.
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    FireWeapon();
                }
            }
            else
            {
                controllerMesh.SetActive(true);
            }
        }
    }

    private void FireWeapon()
    {
        // Play the fire sound
        AudioSource.PlayClipAtPoint(fireSound, transform.position);

        // Instantiate the bullet
        GameObject bullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);

        // Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward.normalized * bulletVelocity, ForceMode.Impulse);

        // Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeSpawn));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}