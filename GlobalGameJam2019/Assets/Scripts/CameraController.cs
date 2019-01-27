using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    float interp;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 0 && player.transform.position.x <= 74)
        {
            interp = speed * Time.deltaTime;
            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interp);
            transform.position = pos;

        }


    }

    
}
