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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
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

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        AddSnakeBody();
    //    }

    //    if(Input.GetKeyDown(KeyCode.F))
    //    {
    //        RemoveSnakeBodyPart();
    //    }
    //}

    public void AddSnakeBody()
    {
        PlayerBodyBehaviour playerBody = Instantiate(snakeBodyToInstanciate, transform.position, Quaternion.identity).GetComponent<PlayerBodyBehaviour>();
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
}
