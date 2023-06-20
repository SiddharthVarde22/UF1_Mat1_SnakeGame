using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Teams
{
    Team1,
    Team2
}

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    Teams playerTeam;

    PlayerMovements playerMovements;

    // Start is called before the first frame update
    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(playerTeam)
        {
            case Teams.Team1:
                TakeWASDInput();
                break;
            case Teams.Team2:
                TakeArrowKeysInput();
                break;
        }
    }

    void TakeWASDInput()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ChangeDirection(Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            ChangeDirection(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeDirection(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeDirection(Vector3.right);
        }
    }

    void TakeArrowKeysInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeDirection(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeDirection(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeDirection(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeDirection(Vector3.right);
        }
    }

    void ChangeDirection(Vector3 direction)
    {
        playerMovements.ChangeMoveDirection(direction);
    }
}
