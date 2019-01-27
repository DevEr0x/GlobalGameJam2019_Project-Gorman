using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    float interp;
    public float minscrollX, maxscrollX, minscrollY, maxscrollY;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
       interp = speed * Time.deltaTime;
        if (player.transform.position.x > minscrollX && player.transform.position.x < maxscrollX)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interp);

            transform.position = pos;
        }
        if (player.transform.position.y > minscrollY && player.transform.position.y < maxscrollY)
        {
            Vector3 pos = transform.position;
            pos.y = Mathf.Lerp(transform.position.y, player.transform.position.y, interp);

            transform.position = pos;
        }

    }

    
        
        
    
}
