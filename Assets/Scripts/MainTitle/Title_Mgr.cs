﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Mgr : MonoBehaviour
{
    public Image m_Fade;
    //페이드 인아웃 값
    private float m_OutTtme = 0f;
    private float m_Fadeout = 0f;

    //씬 이동 버튼
    public Button m_Button;
    public bool m_ButtonT = false;

    public GameObject Ground;
    private Ground ground;

    [Header("Option")]
    public Button Option_Btn;
    public Image Option;
    public Button Option_Close;

    void Start()
    {
        if (Option_Btn != null)
        {
            Option_Btn.onClick.AddListener(() =>
            {
                Option.gameObject.SetActive(true);
            });
        }

        if (Option_Close != null)
            Option_Close.onClick.AddListener(() =>
            {
                Option.gameObject.SetActive(false);
            });
        if (m_Button != null)
        {
            m_Button.onClick.AddListener(() =>
            {
                m_ButtonT = true;
            });
        }

        ground = Ground.GetComponent<Ground>();
    }

    void Update()
    {
        FadeOut();
    }

    void FadeOut()
    {

        if (ground.m_BallT == true )
        {
            m_Fade.gameObject.SetActive(true);

            m_OutTtme += Time.deltaTime;
            if (m_Fadeout < 1.0f && m_OutTtme > 0.1f)
            {
                m_Fadeout += 0.1f;
                m_Fade.color = new Color(0, 0, 0, m_Fadeout);
                m_OutTtme = 0;
            }
            else if (m_Fadeout > 1.0f)
            {
                m_OutTtme = 0;
                m_Fadeout = 1.0f;


                m_ButtonT = false;

                SceneManager.LoadScene("InGame");
            }
        }
    }
}

    

