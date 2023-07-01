using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject ImpactEffect;

    private Transform target;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
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
    }

    void HitTarget()
    {
        GameObject EffectInst = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(EffectInst, 2f);
        Destroy(gameObject);
    }
}
