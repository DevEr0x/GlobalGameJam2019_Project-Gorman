using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyPatrol enemy;
    EnemyPatrol inst;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("gsrgfsd");
        inst = Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        inst.currentPat = EnemyPatrol.patrolPat.DIAGONAL;
        inst.speed = 5.0f;
        inst.maxDist = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
