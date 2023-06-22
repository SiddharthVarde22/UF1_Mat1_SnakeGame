using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour
{
    [SerializeField]
    Color color = Color.white;
    [SerializeField]
    List<PlayerBodyBehaviour> snakeBodyParts;

    [SerializeField]
    Teams playerTeam;
    [SerializeField]
    GameObject snakeBodyToInstanciate;

    PlayerMovements playerMovements;

    bool hasShield = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
        playerMovements = GetComponent<PlayerMovements>();
    }

    public void MovePlayerSnakeBody(Vector3 lastHeadPosition)
    {
        if(snakeBodyParts.Count == 0)
        {
            return;
        }

        for(int i = snakeBodyParts.Count - 1; i > 0; i--)
        {
            snakeBodyParts[i].SetPosition(snakeBodyParts[i - 1].GetComponent<Transform>().position);
        }

        snakeBodyParts[0].SetPosition(lastHeadPosition);
    }

    public void AddSnakeBody()
    {
        Vector3 positionToSpawn;
        Vector3 direction = playerMovements.GetCurrentMoveDirection();

        if (snakeBodyParts.Count > 0)
        {
            positionToSpawn = snakeBodyParts[snakeBodyParts.Count - 1].transform.position - direction - direction * 0.1f;
        }
        else
        {

            positionToSpawn = transform.position - direction - direction * 0.1f;
        }

        PlayerBodyBehaviour playerBody = Instantiate(snakeBodyToInstanciate, positionToSpawn, Quaternion.identity).GetComponent<PlayerBodyBehaviour>();
        playerBody.SetColor(color);
        playerBody.SetTeam(playerTeam);
        snakeBodyParts.Add(playerBody);
    }

    public void RemoveSnakeBodyPart()
    {
        if (snakeBodyParts.Count > 0)
        {
            PlayerBodyBehaviour partToRemove = snakeBodyParts[snakeBodyParts.Count - 1];
            snakeBodyParts.RemoveAt(snakeBodyParts.Count - 1);

            Destroy(partToRemove.gameObject);
        }
    }

    public void OnSnakeDied()
    {
        for(int i = snakeBodyParts.Count - 1; i >= 0; i--)
        {
            RemoveSnakeBodyPart();
        }
        //Tell game manager that this player died
        Destroy(gameObject);
    }

    public void ChangeHasShield(bool value)
    {
        hasShield = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBodyController otherPlayerBodyController = null;
        PlayerBodyBehaviour bodyThatSnakeCollidedWith = null;

        if (hasShield == false)
        {
            if (collision.gameObject.TryGetComponent<PlayerBodyController>(out otherPlayerBodyController))
            {
                if (otherPlayerBodyController.playerTeam != playerTeam)
                {
                    //otherPlayerBodyController.OnSnakeDied();
                    GamePlayManager.Instance.OnBothPlayerDied();
                    GameStopBehaviour.Instance.GameStoped();

                }
            }
            else if (collision.gameObject.TryGetComponent<PlayerBodyBehaviour>(out bodyThatSnakeCollidedWith))
            {
                GamePlayManager.Instance.OnPlayerDied(bodyThatSnakeCollidedWith);
                GameStopBehaviour.Instance.GameStoped();
            }
        }
    }
}
