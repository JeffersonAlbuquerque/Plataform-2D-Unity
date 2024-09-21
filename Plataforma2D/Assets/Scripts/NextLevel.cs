using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private Animator FlagAnim;
    public int IndexLevel;

    // Start is called before the first frame update
    void Start()
    {
        FlagAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {

            StartCoroutine(animNextLevel());

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            FlagAnim.SetBool("isFlag", false);
        }

    }

    IEnumerator animNextLevel()
    {
        FlagAnim.SetBool("isFlag", true);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(IndexLevel);
    }
}
