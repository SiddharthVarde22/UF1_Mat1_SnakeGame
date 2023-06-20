using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 2;

    float maximumXposition, minimumXposition, maximumYPosition, minimumYposition;

    // Start is called before the first frame update
    void Start()
    {
        minimumXposition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x - (transform.localScale.x / 2);
        maximumXposition = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x + (transform.localScale.x / 2);

        minimumYposition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - (transform.localScale.y / 2);
        maximumYPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y + (transform.localScale.y / 2);

        Debug.Log("minx " + minimumXposition + " maxX " + maximumXposition + " minY " + minimumYposition + " maxY " + maximumYPosition);
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayerHead();
    }

    void MovePlayerHead()
    {
        transform.position += transform.right * playerSpeed * Time.deltaTime;
        CheckForScreenWrap();
    }

    void CheckForScreenWrap()
    {
        if(transform.position.x >= maximumXposition)
        {
            transform.position = new Vector3(minimumXposition + 0.1f, transform.position.y, 0);
        }
        else if(transform.position.x <= minimumXposition)
        {
            transform.position = new Vector3(maximumXposition - 0.1f, transform.position.y, 0);
        }

        if(transform.position.y >= maximumYPosition)
        {
            transform.position = new Vector3(transform.position.x, minimumYposition + 0.1f, 0);
        }
        else if(transform.position.y <= minimumYposition)
        {
            transform.position = new Vector3(transform.position.x, maximumYPosition - 0.1f, 0);
        }
    }
}
