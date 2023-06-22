using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    float minimumTimeToSpawnItem, maximumTimeToSpawnItem;
    [SerializeField]
    float distanceToAvoidSpawningNearBoundries = 1;

    float timeToSpawnItem;

    [SerializeField]
    GameObject[] itemPrefabsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawnItem = CalculateRandomFoodSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawnItem -= Time.deltaTime;

        if(timeToSpawnItem <= 0)
        {
            int itemIndex = Random.Range(0, itemPrefabsToSpawn.Length);

            Vector3 randomPosition = new Vector3(
                Random.Range(ScreenBoundsCalculator.Instance.MinimumXPosition + distanceToAvoidSpawningNearBoundries
                    , ScreenBoundsCalculator.Instance.MaximumXPosition - distanceToAvoidSpawningNearBoundries),
                Random.Range(ScreenBoundsCalculator.Instance.MinimumYPosition + distanceToAvoidSpawningNearBoundries
                    , ScreenBoundsCalculator.Instance.MaximumYPosition - distanceToAvoidSpawningNearBoundries),
                0);

            Instantiate(itemPrefabsToSpawn[itemIndex], randomPosition, Quaternion.identity);
            timeToSpawnItem = CalculateRandomFoodSpawnTime();
        }
    }

    float CalculateRandomFoodSpawnTime()
    {
        if(minimumTimeToSpawnItem >= maximumTimeToSpawnItem)
        {
            maximumTimeToSpawnItem = minimumTimeToSpawnItem + 2;
        }
        return Random.Range(minimumTimeToSpawnItem, maximumTimeToSpawnItem);
    }
}
