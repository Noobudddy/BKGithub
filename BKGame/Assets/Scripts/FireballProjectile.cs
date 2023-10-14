using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    private bool collided;

    private int fireballLayer;
    private int playerLayer;
    private int mainCameraLayer;

    public GameObject fireballExplosion;

    private void Awake()
    {
        // Assign layer IDs to the appropriate layers
        fireballLayer = LayerMask.NameToLayer("Fireball");
        playerLayer = LayerMask.NameToLayer("Player");
        mainCameraLayer = LayerMask.NameToLayer("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        int otherLayer = other.gameObject.layer;

        if (otherLayer == fireballLayer || otherLayer == playerLayer || otherLayer == mainCameraLayer || collided)
        {
            return;
        }

        collided = true;

        var explosion = Instantiate(fireballExplosion, other.transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 2);

        Debug.Log("Fireball hit");

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int otherLayer = collision.gameObject.layer;

        if (otherLayer != fireballLayer && otherLayer != playerLayer && otherLayer != mainCameraLayer && !collided)
        {
            collided = true;

            var explosion = Instantiate(fireballExplosion, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(explosion, 2);

            Destroy(gameObject);
        }
    }
}
