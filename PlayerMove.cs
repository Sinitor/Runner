using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float swipeSpeed;
    public GameObject player;
    private float x1;
    private float x2;
    private float move = 0;
    public Animator anim;



    private void Update()
    {
        Move(); 
    }

    private void Move()
    {
        player.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            x1 = Input.mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            x2 = Input.mousePosition.x;

            if (x1 > x2)
            {
                move = 1f;
            }
            if (x2 > x1)
            {
                move = 2f;
            }
        } 
         if (move == 1f && transform.position.x >= -4)
            {
                player.transform.Translate(Vector2.left * (swipeSpeed * Time.deltaTime));
            }
            if (move == 2f && transform.position.x <= 4)
            {
                player.transform.Translate(Vector2.right * (swipeSpeed * Time.deltaTime));
            }
    }
}
