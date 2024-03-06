using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beerbottle : MonoBehaviour
{
    public List<Rigidbody> allParts = new List<Rigidbody>();
    public AudioSource bottleCrash;

    private void Awake()
    {
        bottleCrash = GetComponent<AudioSource>();
    }
    public void Shatter()
    {

        foreach (Rigidbody part in allParts)
        {
            part.isKinematic = false;
        }
        bottleCrash.Play();
        Destroy(gameObject, 1f);
    }
}