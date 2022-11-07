using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] GameObject hitVFX;
     [SerializeField] int scorePerHit = 15;

   
    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    void Start()
    {
        AddRigidbody();
        parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void OnParticleCollision(GameObject other)
    {
        if (hitPoints < 1) { StartDeathSequence(); }     
        ProcessHit();
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(scorePerHit);
        hitPoints--;

    }

    void StartDeathSequence(){
        GameObject vfx = Instantiate(deathVFX,transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
