using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 1f;

    [SerializeField]
    float speedMultiplier = 0.5f;

    [SerializeField]
    float chillMultiplier = 10f;
    [SerializeField]
    public Vector2 speedRandomMultiplier;

    float chasingHeightOffset = 0.25f;

    private Vector2 playerPosition;

    private bool reachedRight = false, reachedLeft = true;

    [SerializeField]
    public float rayDistance = 0.69f;

    [SerializeField]
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (MoveSpeed == 0f) MoveSpeed = 1;
        if (speedMultiplier == 0f) speedMultiplier = 1;
        if (chillMultiplier == 0f) chillMultiplier = 69f;
        if (speedRandomMultiplier.x < 1) speedRandomMultiplier.x = 1f;
        if (speedRandomMultiplier.y < 1) speedRandomMultiplier.x = 2f;

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // CHASE OR PATROL
        playerPosition = GameManager.Instance.Player.transform.position;
        if (playerPosition.y >= gameObject.transform.position.y - chasingHeightOffset)
        {
            // THEN MOVE LEFT OR RIGHT
            if (playerPosition.x > gameObject.transform.position.x)
            {
                Walk(true);
            }
            else
            {
                Walk(false);
            }
        }
        else
        {
            Patrol();
        }

    }

    private void Patrol()
    {

        if (CanGo(true) && !reachedRight) Chill(true);
        else
        {
            if (CanGo(false) && !reachedLeft) Chill(false);
        }
    }

    private bool CanGo(bool isRight)
    {
        Vector2 rightPosition = new Vector2(1, -1);
        Vector2 leftPosition = new Vector2(-1, -1);
        RaycastHit2D hit;

        if (isRight) hit = Physics2D.Raycast(transform.position, rightPosition, rayDistance);
        else hit = Physics2D.Raycast(transform.position, leftPosition, rayDistance);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                return true;
            }
            else
            {
                Debug.Log($"Cant walk on {hit.collider.gameObject}");
                return false;
            }
        }
        else
        {
            ReachedPlatformEnd();
            return false;
        }
    }

    private void Walk(bool isRight)
    {
        if (isRight) transform.Translate(new Vector3(speedMultiplier * MoveSpeed * Time.deltaTime, 0f, 0f));
        else transform.Translate(new Vector3((-1) * speedMultiplier * MoveSpeed * Time.deltaTime, 0f, 0f));

    }

    private void Chill(bool isRight)
    {
        if (isRight) rb.velocity = new Vector2(RandomSpeedFactor() * chillMultiplier * speedMultiplier * MoveSpeed * Time.deltaTime, 0f);
        else rb.velocity = new Vector2(RandomSpeedFactor() * -chillMultiplier * speedMultiplier * MoveSpeed * Time.deltaTime, 0f);
    }

    private void ReachedPlatformEnd()
    {
        reachedRight = !reachedRight;
        reachedLeft = !reachedLeft;
    }

    private float RandomSpeedFactor()
    {
        return Random.Range(speedRandomMultiplier.x, speedRandomMultiplier.y);
    }

}
