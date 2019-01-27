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
        Vector3 pos = transform.position;
        if (player.transform.position.x > minscrollX && player.transform.position.x < maxscrollX)
        {
            pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interp);

        }
        if (player.transform.position.y > minscrollY && player.transform.position.y < maxscrollY)
        {
            pos.y = Mathf.Lerp(transform.position.y, player.transform.position.y, interp);

        }
        transform.position = pos;

    }





}
