using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    [Header("Life Settings")]
    public float LifeMaximum;
    public float CurrentLife;
    [Header("HUD Life")]
    public Image LifeBar;

    private void Start()
    {
        CurrentLife = LifeMaximum;
    }
    // Update is called once per frame
    void Update()
    {
        LifeBar.fillAmount = CurrentLife / LifeMaximum;

        if (CurrentLife <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //recharg scene index;
        }
    }

    public void damagePlayer(float DamagePlataform)
    {
        CurrentLife -= DamagePlataform;
    }
}
