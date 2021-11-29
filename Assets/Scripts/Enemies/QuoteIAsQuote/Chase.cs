using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    float MoveSpeed;

    private Vector2 toMove;

    [SerializeField]
    private int factor = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (MoveSpeed != null) MoveSpeed /= factor;
        else MoveSpeed = 2 / factor;
    }

    // Update is called once per frame
    void Update()
    {
        toMove = new Vector2(MoveSpeed * Time.fixedDeltaTime, 0f);
        rb.AddForce(toMove, ForceMode2D.Impulse);
    }

}
