using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

     [SerializeField] float loadDelay = 1f;
     [SerializeField] ParticleSystem explosionVFX;

     void OnTriggerEnter(Collider other)
     {
          StartCrashSequence();
          
     }

     void StartCrashSequence()
     {
          explosionVFX.Play();
          GetComponent<MeshRenderer>().enabled = false;
          GetComponent<PlayerControlls>().enabled = false;
          Invoke("ReloadLevel", loadDelay);
     }

     void ReloadLevel()
     {
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(currentSceneIndex);
     }

}
