using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
    public GameObject controllerMesh;
    public float bulletLifeSpawn = 5f; // Lifespan of the bullet in seconds
    public float bulletVelocity = 30;



    void Update()
    {
        // Check if the object this script is attached to is being grabbed by the player.
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
            controllerMesh.SetActive(false);
            // Check if the player's secondary hand trigger (usually the index finger) is being pressed.
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
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
        //Instantiate the bullet
        GameObject bullet = Instantiate(Bullet,shootPoint.position, Quaternion.identity);

        //Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeSpawn));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}

