using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float maxDist;
    Rigidbody2D rb;
    public float speed;

    public enum patrolPat
    {
        HORIZONTAL,
        VERTICAL,
        CIRCULAR,
        DIAGONAL
    }

    public patrolPat currentPat;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentPat)
        {
            case patrolPat.HORIZONTAL:
                transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), transform.position.y);      
                break;
            case patrolPat.VERTICAL:
                transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1));
                break;
            case patrolPat.CIRCULAR:
                break;
            case patrolPat.DIAGONAL:
                transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1));
                break;
        }


    }
        //if (currentPat == patrolPat.HORIZONTAL)
        //{
        //    transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), transform.position.y);
        //}

        //if (currentPat == patrolPat.VERTICAL)
        //{
        //    transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1));
        //}

        //if(currentPat == patrolPat.DIAGONAL)
        //{
        //    transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1));
        //}

    }

