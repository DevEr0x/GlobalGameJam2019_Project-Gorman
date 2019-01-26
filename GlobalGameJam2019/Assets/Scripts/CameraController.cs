using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    float interp;
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

     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 pos = cam.transform.position;
            pos.x = Mathf.Lerp(cam.transform.position.x, player.transform.position.x, interp);

            cam.transform.position = pos;
        }
    }
}
