using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision objectHitten)
    {
        Debug.Log("Collision detected");

        if (objectHitten.gameObject.CompareTag("Beer"))
        {
            GameManager beerCounter = FindObjectOfType<GameManager>();
            objectHitten.gameObject.GetComponent<Beerbottle>().Shatter();
            beerCounter.DecrementBottleCount();
        }

    }
}

