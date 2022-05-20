using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    private float platformCount = 3f;
    [SerializeField]
    private GameObject[] platformPrefabs;
    private float minDistanceBetweenPlatforms = Constants.Platforms.minDistanceBetweenPlatforms;
    private float maxDistanceBetweenPlatforms = Constants.Platforms.maxDistanceBetweenPlatforms;

    private float lastPlatformPositionY = 3f;
    private int minHeightToContinueGeneratingPlatforms = 20;

    [SerializeField]
    private float minX, maxX;

    protected void Awake()
    {
        // SetMinAndMaxX();
        CreatePlatforms();
    }

    private float xPosition()
    {
        return Random.Range(minX, maxX);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Constants.Platforms.platformTag && lastPlatformPositionY - GameManager.Instance.Player.transform.position.y < minHeightToContinueGeneratingPlatforms)
        {
            PositionNewPlatform();
        }
    }

    private void CreatePlatforms()
    {
        for (int i = 0; i < platformCount; i++)
        {
            PositionNewPlatform();
        }
    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

         maxX = bounds.x + 0.5f;
         minX = -bounds.x - 0.5f;
    }

    public void PositionNewPlatform()
    {
        GameObject platform = Instantiate(GetRandomPlatformPrefab());
        Vector3 platformPosition = platform.transform.position;
        platformPosition.x = xPosition();
        platformPosition.y = lastPlatformPositionY;

        /// if (lastPlatformPositionX < 0) platformPosition.x = Random.Range(Constants.Platforms.randomHorizontalOffset, maxX);
        // else platformPosition.x = Random.Range(minX, -Constants.Platforms.randomHorizontalOffset);
        
        platform.transform.position = platformPosition;
        lastPlatformPositionY += Random.Range(minDistanceBetweenPlatforms, maxDistanceBetweenPlatforms);
    }

    private struct Constants
    {
        public struct Platforms
        {
            public const float minDistanceBetweenPlatforms = 2.5f;
            public const float maxDistanceBetweenPlatforms = 4.75f;
            public const float randomHorizontalOffset = 6f;
            public const string platformTag = "Floor";
        }
    }

    private GameObject GetRandomPlatformPrefab()
    {
        int index = Random.Range(0, platformPrefabs.Length);
        return platformPrefabs[index];
    }



}
