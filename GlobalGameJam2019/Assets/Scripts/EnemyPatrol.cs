using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float maxDist;
    Rigidbody2D rb;
    Vector3 rotationCenter;
    public float speed;
    Vector3 startpos;

    public float rotationRadius = 10f;

   private float posX, posY, angle = 0f;

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
        startpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }


    }
      

    }

