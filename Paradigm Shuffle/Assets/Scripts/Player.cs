using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float playerSpeed; //speed player moves
    public bool hardLock;
    public GameObject decks;
    public Animator playerAnim;

    public float maxHp = 100f;
    public float hp;
    public float damageReducFlat;
    public float damageReducPercent;

    private void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        hp = maxHp;
    }

    void Update()
    {

        MoveForward(); // Player Movement 
    }

    void MoveForward()
    {

        if (hardLock)
        {

            if (Input.GetKey("a") && gameObject.transform.position.x > -6.46)//go left
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                playerAnim.Play("player_right");

                if (Input.GetKey("w") && gameObject.transform.position.y < 4.90)//go up
                {
                    transform.Translate(0, playerSpeed * Time.deltaTime, 0);
                }
                if (Input.GetKey("s") && gameObject.transform.position.y > -3.9)//go down
                {
                    transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
                }
            }
            else if (Input.GetKey("d") && gameObject.transform.position.x < 6.39)//go right
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_right");

                if (Input.GetKey("w") && gameObject.transform.position.y < 4.90)//go up
                {
                    transform.Translate(0, playerSpeed * Time.deltaTime, 0);
                }
                if (Input.GetKey("s") && gameObject.transform.position.y > -3.9)//go down
                {
                    transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
                }
            }
            else if (Input.GetKey("w") && gameObject.transform.position.y < 4.90)//go up
            {
                transform.Translate(0, playerSpeed * Time.deltaTime, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_up");
            }
            else if(Input.GetKey("s") && gameObject.transform.position.y > -3.9)//go down
            {
                transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_down");
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                playerAnim.Play("player_idle");
            }



        }
        else
        {
            if (Input.GetKey("w"))//go up
            {
                transform.Translate(0, playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("s"))//go down
            {
                transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey("a"))//go left
            {
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey("d"))//go right
            {
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            }
        }
    }
}
