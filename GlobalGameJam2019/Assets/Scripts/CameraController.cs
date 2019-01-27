using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    float interp;
    public float minscroll, maxscroll;
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
        if (player.transform.position.x > minscroll && player.transform.position.x < maxscroll)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interp);

            transform.position = pos;
        }

    }

    
        
        
    
}
