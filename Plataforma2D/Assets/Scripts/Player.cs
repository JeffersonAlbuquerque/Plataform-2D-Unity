using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    private Rigidbody2D Rig; //reference to the rigidbody 2d, this have mass, and physical to the player.
    private Animator Anim; //reference animations to the player, for example, walk, jump and idle.
    public float Speed; //reference to the speed Player//
    public float JumpForce;
    public bool isJump;
    public bool isDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>(); //get components rigidbody2d;
        Anim = GetComponent<Animator>();    //get components Animator;
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //reference to the class move.
        Jump();
    }
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //using vector3 beacause vector2 doesn't acess component transform.position.
        transform.position += movement * Time.deltaTime * Speed; //this is reference to the movement player, get the transform and add movement(vector3) and multiply to the time.deltaTime and speed.

        if (Input.GetAxis("Horizontal") > 0f)
        {
            Anim.SetBool("isWalk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f); //rotate object if the walk to the right > 0
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            Anim.SetBool("isWalk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);//rotate player if the player walk to the left 180f;
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            Anim.SetBool("isWalk", false);
        }
    }
    public void TrampolineActive()
    {
        Rig.AddForce(new Vector2(0f, JumpForce * 2), ForceMode2D.Impulse);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")) //get the imput "JUMP" unity.
        {
            if (isJump == false) //if isJump false, execute rig.AddForce (jump) and have the option to the doubleJump..
            {
                Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //addForce requires forceMode2d is either impulse or force.
                isDoubleJump = true;
                Anim.SetBool("isJump", true);
            }
            else
            {
                if (isDoubleJump == true)
                {
                    Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //addForce requires forceMode2d is either impulse or force.
                    isDoubleJump = false;
                    Anim.SetBool("isDoubleJump", true);
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //
    {
        if (collision.gameObject.layer == 8)
        {
            isJump = false;
            Anim.SetBool("isJump", false);
            Anim.SetBool("isDoubleJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJump = true;
        }
    }
}
