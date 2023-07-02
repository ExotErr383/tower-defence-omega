using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    public float speed = 7f;
    public float startHealth = 30f;
    public int value = 2;

    [Header("Unity attributes")]
    public Image healthBar;

    private float health;
    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
        health = startHealth;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.3) 
        {
            GetNextWaypoint();
        }
    }
    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return; 
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        healthBar.fillAmount = health / startHealth;
        Debug.Log(healthBar.fillAmount);
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }
}
