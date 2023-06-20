using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    float playerSpeed = 5;

    float maximumXposition, minimumXposition, maximumYPosition, minimumYposition;

    float timeToMove;
    Vector3 lastHeadPosition;

    PlayerBodyController playerSnakeBodyController;

    Vector3 currentMoveDirection = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        minimumXposition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        maximumXposition = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

        minimumYposition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        maximumYPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;

        lastHeadPosition = transform.position;
        playerSnakeBodyController = GetComponent<PlayerBodyController>();
    }


    //Update is called once per frame
    void Update()
    {
        MovePlayerHead();
    }

    void MovePlayerHead()
    {
        timeToMove += Time.deltaTime;

        if (timeToMove >= (1 / playerSpeed))
        {
            lastHeadPosition = transform.position;
            transform.position += (currentMoveDirection / 2) + (currentMoveDirection * 0.1f);

            playerSnakeBodyController.MovePlayerSnakeBody(lastHeadPosition);

            timeToMove = 0;
        }
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

    public void ChangeMoveDirection(Vector3 nextMoveDirection)
    {
        if(currentMoveDirection != nextMoveDirection && currentMoveDirection != -nextMoveDirection)
        {
            currentMoveDirection = nextMoveDirection;
        }
    }
}
