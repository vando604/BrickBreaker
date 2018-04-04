using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManagerScript levelManager;

   void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("Collision");
    }


    private void OnTriggerEnter2D(Collider2D collider){
        print("Trigger");
        levelManager.LoadLevel("Lose");
    }
}
