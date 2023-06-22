using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeOfPowerUp
{
    Shield,
    Score,
    Speed
}
public class PowerUpBehaviour : MonoBehaviour
{
    [SerializeField]
    float coolDownTime = 3f;
    [SerializeField]
    TypeOfPowerUp powerUpType;
    [SerializeField]
    float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupController powerUpActivator = null;
        //start the power up
        if(collision.TryGetComponent<PowerupController>(out powerUpActivator))
        {
            if (powerUpActivator.GetIsPoweredUp() == false)
            {
                powerUpActivator.StartPowerUp(coolDownTime, powerUpType);
                //destroy self
                Destroy(gameObject);
            }
        }
    }
}
