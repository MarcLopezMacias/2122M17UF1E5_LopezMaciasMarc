using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private Vector3 playerPosition;
    private Rigidbody2D rb;

    [SerializeField]
    float MoveSpeed;

    private Vector2 toMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerPosition = GameManager.Instance.Player.transform.position;
        MoveSpeed /= 10;
    }

    // Update is called once per frame
    void Update()
    {
        toMove = new Vector2(MoveSpeed * Time.fixedDeltaTime, 0f);
        rb.AddForce(toMove, ForceMode2D.Impulse);
    }

}
