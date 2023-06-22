using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundsCalculator : MonoBehaviour
{
    public static ScreenBoundsCalculator Instance { get; private set; }

    public float MaximumXPosition { get; private set; }
    public float MinimumXPosition { get; private set; }
    public float MinimumYPosition { get; private set; }
    public float MaximumYPosition { get; private set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        CalculateBounds();
    }

    void CalculateBounds()
    {
        MinimumXPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        MaximumXPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

        MinimumYPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        MaximumYPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
    }
}
