using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision objectHitten)
    {
        Debug.Log("Collision detected");

        if (objectHitten.gameObject.CompareTag("Beer"))
        {
            Debug.Log("Beer bottle hit");
            objectHitten.gameObject.GetComponent<Beerbottle>().Shatter();
        }

    }
}

