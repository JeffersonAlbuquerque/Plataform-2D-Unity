using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator Anim;
    public Transform HeadPoint;
    public bool Direction; //true is right, and false is left.//
    public float MoveTime; //move necessary to the change position//
    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= MoveTime)
        {
            Timer = 0;
            Direction =! Direction;
        }

        if (Direction)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LifePlayer life = collision.gameObject.GetComponent<LifePlayer>();
            if (life != null)
            {
                life.damagePlayer(5f);
            }

        }

        float height = collision.contacts[0].point.y - HeadPoint.position.y; 

        if (height > 0)
        {
            Anim.SetBool("isDead", true);

            Destroy(this.gameObject, 1f); //wait a 2 seconds to the destroy enemy.
        }
    }
}
