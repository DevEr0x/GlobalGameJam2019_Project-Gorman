using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float maxDist;
    public GameObject ball;
    GameObject ballInst;
    Rigidbody2D rb;
    Vector3 rotationCenter;
    public float speed;
    Vector3 startpos;
    Vector3 ballPos;

    public float rotationRadius = 10f;
    public float throwRate, throwWait;

   private float posX, posY, angle = 0f;

    public enum patrolPat
    {
        HORIZONTAL,
        VERTICAL,
        CIRCULAR,
        DIAGONAL,
        BALL
    }

    public patrolPat currentPat;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ballPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        rotationCenter.x = startpos.x;
        rotationCenter.y = startpos.y-0.4f;

        posX = rotationCenter.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.y + Mathf.Sin(angle) * rotationRadius;
        switch (currentPat)
        {
            case patrolPat.HORIZONTAL:
                transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), transform.position.y);      
                break;
            case patrolPat.VERTICAL:
                transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1));
                break;
            case patrolPat.CIRCULAR:
                transform.position = new Vector2(posX, posY);
                angle = angle + Time.deltaTime * speed;
                if (angle >= 360f)
                    angle = 0f;
                break;
            case patrolPat.DIAGONAL:
                transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1));
                break;
            case patrolPat.BALL:
                if (ballInst == null)
                {
                    ballInst = Instantiate(ball, ballPos, Quaternion.identity);
                }
                break;
        }


    }

    void ThrowBall()
    {
        ballInst.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, speed, 0), ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Invoke("ThrowBall", 3);
        }
    }


}

