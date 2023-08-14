﻿
using UnityEngine;
using UnityEngine.UI;

public class BarraO2 : MonoBehaviour
{
    [SerializeField] RectTransform indicador;
    [SerializeField] Image indicadorI, barraI;
    [SerializeField] Text porcentagem;
    Color barraC;
    public static float O2;

    void Start()
    {
        O2 = 100;
    }

    void Update()
    {
        porcentagem.text = (O2.ToString("N1") + "%");
        indicador.anchoredPosition = new Vector3(0, -183.88f + ((O2 / 50) * 183.88f));
        if (O2 > 0)
        {
            O2 -= (Time.deltaTime * 2.00f);
        }
        if (O2 > 100)
        {
            O2 = 100;
        }
        GetComponent<Animator>().SetBool("Piscando", (O2 <= 10)? true : false);
    }
}
