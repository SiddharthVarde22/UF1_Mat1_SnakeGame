using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    float minimumTimeToSpawnFood, maximumTimeToSpawnFood;
    [SerializeField]
    float distanceToAvoidSpawningNearBoundries = 1;

    float timeToSpawnFood;

    [SerializeField]
    GameObject[] foodPrefabsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawnFood = CalculateRandomFoodSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawnFood -= Time.deltaTime;

        if(timeToSpawnFood <= 0)
        {
            int foodIndex = Random.Range(0, foodPrefabsToSpawn.Length);

            Vector3 randomPosition = new Vector3(
                Random.Range(ScreenBoundsCalculator.Instance.MinimumXPosition + distanceToAvoidSpawningNearBoundries
                    , ScreenBoundsCalculator.Instance.MaximumXPosition - distanceToAvoidSpawningNearBoundries),
                Random.Range(ScreenBoundsCalculator.Instance.MinimumYPosition + distanceToAvoidSpawningNearBoundries
                    , ScreenBoundsCalculator.Instance.MaximumYPosition - distanceToAvoidSpawningNearBoundries),
                0);

            Instantiate(foodPrefabsToSpawn[foodIndex], randomPosition, Quaternion.identity);
            timeToSpawnFood = CalculateRandomFoodSpawnTime();
        }
    }

    float CalculateRandomFoodSpawnTime()
    {
        if(minimumTimeToSpawnFood >= maximumTimeToSpawnFood)
        {
            maximumTimeToSpawnFood = minimumTimeToSpawnFood + 2;
        }
        return Random.Range(minimumTimeToSpawnFood, maximumTimeToSpawnFood);
    }
}
