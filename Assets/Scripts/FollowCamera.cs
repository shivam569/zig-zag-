using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public GameObject ball;
   
    Vector3 offset;

    public float lerpRate;
    public bool gameOver;


    void Start() {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

  
    void Update() {
        if(!gameOver) {
            FollowTheBall();
        }
    }

    void FollowTheBall() {
   
        Vector3 pos = transform.position;
        Vector3 targetPosition = ball.transform.position - offset;
      
        pos = Vector3.Lerp(pos, targetPosition, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
