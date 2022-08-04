using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance { get; private set; }
    [SerializeField] private Rigidbody2D rigiBody2d;
    [SerializeField] private float speed;
    public void OnStart()
    {
      /*  rigiBody2d.velocity = Vector2.zero;*/
        transform.position = Vector2.zero;
        rigiBody2d.AddForce(Vector2.down * speed);
    }


    private void Awake()
    {
       Instance = this;
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Rocket"))
        {
            var rocket=other.transform.GetComponent<RocketController>();
            var directionVertical = rocket.isup ? -1 : 1;

            var directionHorizontal = (transform.position.x - rocket.transform.position.x)/other.collider.bounds.extents.x;
            rigiBody2d.AddForce(new Vector3(directionHorizontal, directionVertical).normalized* speed);
        }

        if(other.transform.CompareTag("Obstacle"))
        {
           
            OnStart();
        }
        if (other.transform.CompareTag("ObstacleGameOver"))
        {
            //GameOver
            GameManager.Instance.onGameOver();
            rigiBody2d.velocity = Vector2.zero;
        }

    }
}
