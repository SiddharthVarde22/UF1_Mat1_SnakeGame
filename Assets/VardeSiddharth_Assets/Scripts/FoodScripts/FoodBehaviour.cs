using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoodType
{
    massGainer,
    massBurner
}

[RequireComponent(typeof(BoxCollider2D))]
public class FoodBehaviour : MonoBehaviour
{
    [SerializeField]
    FoodType myFoodType;
    [SerializeField]
    int lenghtToChange = 1, scoreToChange = 10;
    [SerializeField]
    float foodLifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, foodLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerBodyController playerBodyController;
        if (other.gameObject.TryGetComponent<PlayerBodyController>(out playerBodyController))
        {
            // increase or decrease player snake size according to food type
            switch (myFoodType)
            {
                case FoodType.massGainer:
                    for (int i = 0; i < lenghtToChange; i++)
                    {
                        playerBodyController.AddSnakeBody();
                    }
                    break;
                case FoodType.massBurner:
                    for (int i = 0; i < lenghtToChange; i++)
                    {
                        playerBodyController.RemoveSnakeBodyPart();
                    }
                    break;
            }
            Destroy(gameObject);
        }
    }
}
