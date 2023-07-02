using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject ImpactEffect;
    public float explosionRadius = 0f;
    public int damage = 50;

    private Transform target;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;
        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject EffectInst = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(EffectInst, 1f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemyObj)
    {
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        if (enemy != null) enemy.TakeDamage(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
