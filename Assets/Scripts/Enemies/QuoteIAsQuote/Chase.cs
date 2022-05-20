using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    [SerializeField]
    float MoveSpeed = 1f;

    [SerializeField]
    float speedMultiplier = 0.5f;

    float chasingHeightOffset = 0.25f;

    private Vector2 playerPosition;

    private bool patrolling;
    private int waitingSeconds = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // CHECK HEIGHT
        playerPosition = GameManager.Instance.Player.transform.position;
        if(playerPosition.y >= gameObject.transform.position.y - chasingHeightOffset)
        {
            // THEN MOVE LEFT OR RIGHT
            if (playerPosition.x > gameObject.transform.position.x)
            {
                transform.Translate(new Vector3(speedMultiplier * MoveSpeed * Time.deltaTime, 0f, 0f));
            }
            else
            {
                transform.Translate(new Vector3((-1) * speedMultiplier * MoveSpeed * Time.deltaTime, 0f, 0f));
            }
        }
        else
        {
            if (!patrolling)
            {
                // StartCoroutine(Patrol());
            }
        }

    }

    private IEnumerator Patrol()
    {
        // FML
        yield return new WaitForSeconds(waitingSeconds);
    }

}
