using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    public float minHeightToFollow;
    [SerializeField]
    public float heightOffset;

    private float playerHeight, previousHeight; 
    
    Vector3 initialPosition;
    Vector3 newPosition;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = GameManager.Instance.Player.transform.position.y;
        if (previousHeight < playerHeight) previousHeight = playerHeight;
        if(playerHeight > minHeightToFollow && playerHeight >= previousHeight)
        {
            newPosition = new Vector3(initialPosition.x, playerHeight - heightOffset, initialPosition.z);
            gameObject.transform.position = newPosition;
        }
    }

    public void ResetPosition()
    {
        gameObject.transform.position = initialPosition;
        ResetVariables();
    }

    private void ResetVariables()
    {
        Start();
        playerHeight = 0;
        previousHeight = 0;
    }
}
