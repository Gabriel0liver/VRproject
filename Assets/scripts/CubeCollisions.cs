using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisions : MonoBehaviour
{
    AudioManager audioManager;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("MainCamera")){
            audioManager.Play("Hit");
            scoreManager.hitPlayer();
        }
        else
        {
            scoreManager.hitWall();
        }
        Destroy(gameObject);
    }
}
