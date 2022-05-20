using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.EnemiesInGame.Add(this.gameObject);
        XP = 1;
        Damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Jumping"))
        {
            GameObject cl = collision.gameObject;
            cl.GetComponent<DataPlayer>().DecreaseLifes(1);
            Die();
        }
    }

}
