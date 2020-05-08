using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject particle;
    
    [SerializeField]    
    private float speed;

  
    bool started;

    
    bool gameOver;

  
    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    
    void Start() {
        started = false;
        gameOver = false;
    }

   
    void Update() {
        if(!started) {
            if(Input.GetMouseButtonDown(0)) {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

               
                GameManager.instance.GameStart();
            }
        }

  
     
        if(!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
           
            rb.velocity = new Vector3(0, -30f, 0);

       
            Camera.main.GetComponent<FollowCamera>().gameOver = true;

           
            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver) {
            ChangeDirection();
        }
    }

    void ChangeDirection() {
        if (rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed, 0, 0);
        } else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {

            GameObject particleObject = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(other.gameObject);
            Destroy(particleObject, 1f);
        }
    }







}
