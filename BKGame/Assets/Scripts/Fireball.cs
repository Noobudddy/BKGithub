using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Camera cam;
    public GameObject projectile;
    public Transform firePoint;
    public bool CanAttack = true;
    public bool isAttacking = false;
    public int damage;
    public float projectileSpeed = 45;
    public float fireballCooldown = 2.0f;

    private Vector3 destination;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (CanAttack)
            {
                ShootProjectile();
            }
        }
    }

    private void ShootProjectile()
    {

        isAttacking = true; 
        CanAttack = false;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else
            destination = ray.GetPoint(1000);

        if (isAttacking)
        {
            Debug.Log("Fireball is attacking");
        }

        InstantiateProjectile(firePoint);
        StartCoroutine(ResetAttackCooldown());
    }

    private void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(fireballCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(2.0f);
        isAttacking = false;
    }
}
