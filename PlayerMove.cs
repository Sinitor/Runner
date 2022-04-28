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

    public float smooth = 2.0f;

    private Vector3 defaultRot;
    private Vector3 openRot;
    private float open = 0;

    [SerializeField] GameObject Cowboy;
    [SerializeField] GameObject Steampunk;
    [SerializeField] GameObject Jacket;
    [SerializeField] GameObject LeftBoots;
    [SerializeField] GameObject RightBoots;
    [SerializeField] GameObject LeftPinkBoots;
    [SerializeField] GameObject RightPinkBoots;
    [SerializeField] GameObject Mask;
    [SerializeField] GameObject Armor;
    [SerializeField] GameObject MagicHands;
    [SerializeField] GameObject Cask;
    [SerializeField] GameObject DarkMask;
    [SerializeField] GameObject Effect1;
    [SerializeField] GameObject Effect2;
    private void Update()
    {
        Move(); 

        if (open == 1 )
        {
            openRot = new Vector3(defaultRot.x, defaultRot.y + 90, defaultRot.z);
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        if (open == 2)
        {
            openRot = new Vector3(defaultRot.x, defaultRot.y + 180, defaultRot.z);
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
        if (open == 3)
        {
            openRot = new Vector3(defaultRot.x, defaultRot.y + 270, defaultRot.z);
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RotateMove")
        {
            open = 1; 
        }
        if (other.gameObject.tag == "RotateMove1")
        {
            open = 2;
        }
        if (other.gameObject.tag == "RotateMove2")
        {
            open = 3;
        }
        if (other.gameObject.tag == "Box")
        {
            speed = 3;
            anim.SetBool("PickUp", true);
        }
        if (other.gameObject.tag == "Victory")
        {
            speed = 0;
            swipeSpeed = 0;
            anim.SetBool("Victory", true);
            Effect1.gameObject.SetActive(true);
            Effect2.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "CowBoy")
        {
            Cowboy.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Steampunk")
        {
            Steampunk.gameObject.SetActive(true);
            Cowboy.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Jacket")
        {
            Jacket.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "PoloBoots")
        {
            LeftBoots.gameObject.SetActive(true);
            RightBoots.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "PinkBoots")
        {
            LeftPinkBoots.gameObject.SetActive(true);
            RightPinkBoots.gameObject.SetActive(true);
            LeftBoots.gameObject.SetActive(false);
            RightBoots.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Mask")
        {
            Mask.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Armor")
        {
            Armor.gameObject.SetActive(true);
            Jacket.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Magic")
        {
            MagicHands.gameObject.SetActive(true);
            Cowboy.gameObject.SetActive(false);
            Steampunk.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Cask")
        {
            Cask.gameObject.SetActive(true);
            MagicHands.gameObject.SetActive(false);
            Cowboy.gameObject.SetActive(false);
            Steampunk.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "DarkMask")
        {
            DarkMask.gameObject.SetActive(true);
            Mask.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Box")
        {
            speed = 5;
            anim.SetBool("PickUp", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Stop")
        {
            speed = 0;
            swipeSpeed = 0;
            anim.SetBool("Stop", true);
        }
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
        if (open == 0)
        {
            if (move == 1f && transform.position.x >= -4)
            {
                player.transform.Translate(Vector2.left * (swipeSpeed * Time.deltaTime));
            }
            if (move == 2f && transform.position.x <= 4)
            {
                player.transform.Translate(Vector2.right * (swipeSpeed * Time.deltaTime));
            }
        }
        if (open == 1)
        {
            if (move == 1f && transform.position.z <= 97)
            {
                player.transform.Translate(Vector2.left * (swipeSpeed * Time.deltaTime));
            }
            if (move == 2f && transform.position.z >= 88)
            {
                player.transform.Translate(Vector2.right * (swipeSpeed * Time.deltaTime));
            }
        }
        if (open == 2)
        {
            if (move == 1f && transform.position.x <= 94.5)
            {
                player.transform.Translate(Vector2.left * (swipeSpeed * Time.deltaTime));
            }
            if (move == 2f && transform.position.x >= 85.3)
            {
                player.transform.Translate(Vector2.right * (swipeSpeed * Time.deltaTime));
            }
        }
        if (open == 3)
        {
            if (move == 1f && transform.position.z >= -10.8)
            {
                player.transform.Translate(Vector2.left * (swipeSpeed * Time.deltaTime));
            }
            if (move == 2f && transform.position.z <= -1.8)
            {
                player.transform.Translate(Vector2.right * (swipeSpeed * Time.deltaTime));
            }
        }
    }
}
