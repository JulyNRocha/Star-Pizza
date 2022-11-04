using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;

    void OnParticleCollision(GameObject other)
    {
        Instantiate(deathVFX,transform.position, Quaternion.identity);
       
        Destroy(gameObject);
    }
}