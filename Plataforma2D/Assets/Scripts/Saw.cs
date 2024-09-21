using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Timer;
    public float MoveTime;
    public bool DirectionSaw;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= MoveTime)
        {
            Timer = 0;
            DirectionSaw = !DirectionSaw;
        }

        if (DirectionSaw)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LifePlayer life = collision.gameObject.GetComponent<LifePlayer>();
            if (life != null)
            {
                life.damagePlayer(life.LifeMaximum);
            }

        }
    }
}
