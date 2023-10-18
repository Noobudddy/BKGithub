using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballParticle : MonoBehaviour
{
    public float damage = 50f;

    public ParticleSystem fireball;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fireball.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = fireball.GetCollisionEvents(other, colEvents);

        Debug.Log("Fireball hit!");

        for (int i = 0; i < events; i++)
        {

        }

        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(damage);
        }
    }
}
