using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    private bool collided;

    public GameObject fireballExplosion;

    private void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag != "Fireball" && co.gameObject.tag != "Player" && co.gameObject.tag != "MainCamera" && !collided)
        {
            collided = true;

            var explosion = Instantiate(fireballExplosion, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(explosion, 2);

            Destroy(gameObject);
        }
    }
}
