using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 4f;
    public float rotationSpeed = 50f;
    public float fireRate = 2f;

    [Header("Unity attributes")]
    public Transform pivotPoint;
    public string enemyTag = "Enemy";
    public GameObject bulletPref;
    public Transform firePoint;

    private float fireCountdown = 0f;
    private Transform target;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        Vector3 rotation = Quaternion.Lerp(pivotPoint.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        pivotPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f )
        {
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject BulletOBJ = (GameObject)Instantiate(bulletPref, firePoint.position, pivotPoint.rotation);
        Bullet bullet = BulletOBJ.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
