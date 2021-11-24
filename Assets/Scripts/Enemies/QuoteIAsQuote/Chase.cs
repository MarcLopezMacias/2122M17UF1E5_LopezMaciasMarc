using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    Transform Player;

    [SerializeField]
    float MoveSpeed, RotateSpeed;

    [SerializeField]
    int MinDist, MaxDist;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        MoveSpeed /= 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y), MoveSpeed * Time.deltaTime);

    }

}
