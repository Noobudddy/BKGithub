using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    private bool collided;

    private int fireballLayer;
    private int playerLayer;
    private int mainCameraLayer;
    private int enemyLayer;
    private Fireball fb;

    public GameObject fireballExplosion;
    public Rigidbody firerb;
    public float speed;

    private void Update()
    {
        firerb.AddForce(transform.forward * speed);
    }

    private void Awake()
    {
        // Assign layer IDs to the appropriate layers
        fireballLayer = LayerMask.NameToLayer("Fireball");
        playerLayer = LayerMask.NameToLayer("Player");
        mainCameraLayer = LayerMask.NameToLayer("MainCamera");
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        int otherLayer = collision.gameObject.layer;

        if (otherLayer == fireballLayer || otherLayer == playerLayer || otherLayer == mainCameraLayer || collided)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<EnemyMeleeStats>(out EnemyMeleeStats enemyComponent))
        {
            Debug.Log("Fireball damaged enemy!");
            enemyComponent.TakeDamage(fb.damage);
        }

        if (fireballExplosion != null)
        {
            var explosion = Instantiate(fireballExplosion, collision.transform.position, Quaternion.identity) as GameObject;
            Destroy(explosion, 2);
        }

        Debug.Log("Fireball hit");

        collided = true;

        if (collided)
        {
            collided = false;
            Destroy(gameObject);
        }
    }
}
