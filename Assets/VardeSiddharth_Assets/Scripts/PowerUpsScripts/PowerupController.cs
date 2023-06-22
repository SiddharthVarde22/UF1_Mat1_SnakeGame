using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    bool isPoweredUp = false;
    
    public bool GetIsPoweredUp()
    {
        return isPoweredUp;
    }

    public void StartPowerUp(float time, TypeOfPowerUp typeOfPowerUpToStart)
    {
        switch (typeOfPowerUpToStart)
        {
            case TypeOfPowerUp.Shield:
                StartCoroutine(OnShieldCollected(time));
                break;
            case TypeOfPowerUp.Score:
                StartCoroutine(OnScoreBoostCollected(time));
                break;
            case TypeOfPowerUp.Speed:
                StartCoroutine(OnSpeedBoostCollected(time));
                break;
        }
    }

    IEnumerator OnSpeedBoostCollected(float time)
    {
        //increase player speed
        PlayerMovements playerMovements = GetComponent<PlayerMovements>();
        playerMovements.ChangeSpeedIncrement(2);
        isPoweredUp = true;

        yield return new WaitForSeconds(time);

        //decrease player speed
        playerMovements.ChangeSpeedIncrement(0);
        isPoweredUp = false;
    }

    IEnumerator OnScoreBoostCollected(float time)
    {
        //score componant
        PlayerScore playerScore = GetComponent<PlayerScore>();
        //change score multiplier
        playerScore.ChangeScoreMultiplier(2);
        isPoweredUp = true;

        yield return new WaitForSeconds(time);

        //reset score multiplier
        playerScore.ChangeScoreMultiplier(1);

        isPoweredUp = false;
    }

    IEnumerator OnShieldCollected(float time)
    {
        PlayerBodyController playerBodyController = GetComponent<PlayerBodyController>();
        playerBodyController.ChangeHasShield(true);
        isPoweredUp = true;

        yield return new WaitForSeconds(time);

        playerBodyController.ChangeHasShield(false);
        isPoweredUp = false;
    }
}
