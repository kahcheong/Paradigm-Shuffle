using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed; //speed player moves

    void Update()
    {

        MoveForward(); // Player Movement 
    }

    void MoveForward()
    {

        if (Input.GetKey("w") && gameObject.transform.position.y < 4.15)//go up
        {
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s") && gameObject.transform.position.y > -4.1)//go down
        {
            transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a") && gameObject.transform.position.x>-4.42)//go left
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d") && gameObject.transform.position.x < 4.5)//go right
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
    }
}
