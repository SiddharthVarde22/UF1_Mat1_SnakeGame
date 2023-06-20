using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InputMethods
{
    wasd,
    arrowKeys
}

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    InputMethods inputMethod;

    Vector3 targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(inputMethod)
        {
            case InputMethods.wasd:
                TakeWASDInput();
                break;
            case InputMethods.arrowKeys:
                TakeArrowKeysInput();
                break;
        }
    }

    void TakeWASDInput()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            targetRotation = new Vector3(0, 0, 90);
            ChangeHeadDirection(new Vector3(0,0,-90));
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            targetRotation = new Vector3(0, 0, 270);

            ChangeHeadDirection(new Vector3(0, 0, 90));
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            targetRotation = new Vector3(0, 0, 180);
            ChangeHeadDirection(new Vector3(0, 0, 0));
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            targetRotation = new Vector3(0, 0, 0);
            ChangeHeadDirection(new Vector3(0, 0, 180));
        }
    }

    void TakeArrowKeysInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {

        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {

        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
    }

    void ChangeHeadDirection(Vector3 oppositeRotation)
    {
        if (transform.eulerAngles != targetRotation && transform.eulerAngles != oppositeRotation)
        {
            transform.rotation = Quaternion.Euler(targetRotation);
        }
    }
}
