using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        XP = 1;
        Damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLIDED");
        if (collision.CompareTag("Player") || collision.CompareTag("Jumping"))
        {
            Debug.Log("WITH PLAYER");
            GameObject cl = collision.gameObject;
            cl.GetComponent<DataPlayer>().DecreaseLifes(1);
            Die();
        }
    }

}
