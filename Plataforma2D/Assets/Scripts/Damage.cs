using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifePlayer life = collision.gameObject.GetComponent<LifePlayer>();

        if (life != null)
        {
            life.damagePlayer(2f);
        }
    }
}
