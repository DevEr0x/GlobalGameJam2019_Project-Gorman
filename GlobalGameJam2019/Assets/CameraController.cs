using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float interp = speed * Time.deltaTime;

        if (player.transform.position.x >= 0 && player.transform.position.x <= 22)
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interp);

            transform.position = pos;
        }
    }
}
