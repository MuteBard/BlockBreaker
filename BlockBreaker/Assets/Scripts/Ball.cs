using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    Vector2 paddleToBallVector;
    float xPush = 2f;
    float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    [SerializeField] Paddle paddle1;
    [SerializeField] float randomFactor = 0.2f;
    // State
    bool launched = false;
    
    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    void Start()
    {
        //Distance vector
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!launched){
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchBallOnMouseClick()
    {
        //0 represents the left mouse button
        if(Input.GetMouseButtonDown(0)){
            launched = true;
            //we want to push the ball
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweek = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(launched){
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweek;
        }  
    }
}
