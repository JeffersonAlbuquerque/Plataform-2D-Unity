using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItensAccount : MonoBehaviour
{
    [Header("HUD GAME")]
    public Text ItensAccountTxt;
    [SerializeField] public static int itens;

    private void Update()
    {
        ItensAccountTxt.text = itens.ToString();
    }
}
