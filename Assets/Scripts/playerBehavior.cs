﻿
using UnityEngine;
using UnityEngine.UI;

public class playerBehavior : MonoBehaviour
{
    [SerializeField] float xMax, speed, speedC;
    [SerializeField] Image[] vidas;
    [SerializeField] Image fade;
    [SerializeField] Text textoC, textoScore, recorde;
    [SerializeField] GameObject pause, camera;
    [SerializeField] RectTransform home;
    public static int hgScore;
    bool fadeOver;
    float moviment;

    public static float força, speedCenario;
    public static bool pressedL, pressedR ;

    void Start()
    {
        pressedL = false;
        pressedR = false;
        speedCenario = speedC;    
    }
    void Update()
    {
        move();
        limit();
    }

    /// <summary>
    /// Esta função controla o movimento do jogador
    /// </summary>
    void move()
    {
        transform.Translate(Vector3.right * speed * força * Time.deltaTime);
    }

    /// <summary>
    /// Esta função limita o movimento do jogador pela tela
    /// </summary>
    void limit()
    {
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3 (xMax, transform.position.y);
        }
        if (transform.position.x < -xMax)
        {
            transform.position = new Vector3 (-xMax, transform.position.y);
        }
    }

    public void perderVida()
    {
        for (int i = 0; i < vidas.Length; i++)
        {
            if (vidas[i].color == new Color(1,1,1,0.6f))
            {
                vidas[i].color = new Color(0,0,0,0);
                break;
            }
        }
        if(vidas[2].color == new Color(0,0,0,0))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        fade.color = new Color(0,0,0,0.7f);
        SaveLoad.recorde = scoreCount.Count;
        camera.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        textoC.text = "GAME OVER";
        recorde.text = ("Recorde: " + hgScore.ToString());
        textoScore.text = ("Pontos: " + scoreCount.Count);
        Destroy(pause);
        home.anchoredPosition = new Vector2(0,-146);
        Time.timeScale = 0;
    }
}
     

