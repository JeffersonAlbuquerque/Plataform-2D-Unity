using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{

    public Animator AnimTrampoline;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                AnimTrampoline.SetBool("isActiveTrampoline", true);
                player.TrampolineActive();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AnimTrampoline.SetBool("isActiveTrampoline", false);
        }
    }
}
