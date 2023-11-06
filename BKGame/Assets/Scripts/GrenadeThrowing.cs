using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrowing : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject grenadePrefab;


    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            ThrowGrenade();
        }
    }



    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }



}


