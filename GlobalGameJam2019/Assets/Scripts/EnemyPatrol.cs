using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float maxDist;
    Rigidbody2D rb;
    bool x;
    Vector3 startPos;
    float dist;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        x = false;
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Mathf.Sqrt((Mathf.Pow((transform.position.x - startPos.x), 2)));

        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxDist - (maxDist * -1)) + (maxDist * -1), transform.position.y);





    }
}
