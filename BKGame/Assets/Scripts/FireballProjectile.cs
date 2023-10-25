using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    private bool collided = false;

    private int fireballLayer;
    private int playerLayer;
    private int mainCameraLayer;
    private int enemyLayer;
    private Coroutine destroyCoroutine;

    public GameObject fireballExplosion;
    public Rigidbody firerb;
    public float speed;
    public int damage;
    public float destructionTime = 5.0f;

    private void Start()
    {
        firerb.AddForce(transform.forward * speed);
        destroyCoroutine = StartCoroutine(DestroyFireballAfterTime());
    }

    private void Awake()
    {
        // Assign layer IDs to the appropriate layers
        fireballLayer = LayerMask.NameToLayer("Fireball");
        playerLayer = LayerMask.NameToLayer("Player");
        mainCameraLayer = LayerMask.NameToLayer("MainCamera");
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnTriggerEnter(Collider collider)
    {
        int otherLayer = collider.gameObject.layer;

        if (otherLayer == fireballLayer || otherLayer == playerLayer || otherLayer == mainCameraLayer || collided)
        {
            return;
        }

        if (collider.gameObject != null)
        {
            EnemyMeleeStats enemyStats = collider.gameObject.GetComponent<EnemyMeleeStats>();

            if (enemyStats != null)
            {
                Debug.Log("Fireball damaged enemy!");
                enemyStats.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        
        if (fireballExplosion != null)
        {
            var explosion = Instantiate(fireballExplosion, collider.transform.position, Quaternion.identity) as GameObject;
            Destroy(explosion, 2);
        }

        Debug.Log("Fireball hit");
        Debug.Log("Collision with: " + collider.gameObject.name);

        if(destroyCoroutine != null)
        {
            StopCoroutine(destroyCoroutine);
            destroyCoroutine = null;
        }

        collided = true;

        if (collided)
        {
            collided = false;
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyFireballAfterTime()
    {
        yield return new WaitForSeconds(destructionTime);

        if (!collided)
        {
            Destroy(gameObject);
        }
    }
}
