using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyBehaviour : MonoBehaviour
{
    Teams playerTeam;

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }

    public void SetTeam(Teams teams)
    {
        playerTeam = teams;
    }

    public Teams GetTeam()
    {
        return playerTeam;
    }
}
