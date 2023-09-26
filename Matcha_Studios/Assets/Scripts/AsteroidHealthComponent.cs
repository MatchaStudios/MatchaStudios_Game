using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealthComponent : HealthComponent
{
    public GameObject destructionParticles;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }


    //protected override void OnDestroy()
    //{
    //    if (destructionParticles) Destroy(Instantiate(destructionParticles, transform.position, Quaternion.identity), 2f);
    //    // Play explosion sound

    //    base.OnDestroy();
    //}
}
