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
        if (collision.CompareTag("Player"))
        {
            Debug.Log("WITH PLAYER");
            GameObject cl = collision.gameObject;
            cl.GetComponent<DataPlayer>().TakeDamage(Damage);
        }
        Die();
    }

}
