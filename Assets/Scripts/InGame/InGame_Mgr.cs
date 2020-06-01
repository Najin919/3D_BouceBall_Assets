using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGame_Mgr : MonoBehaviour
{
    public Image m_Fade;
    //페이드 인아웃 값
    private float m_InTtme = 0f;
    private float m_FadIn = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn();
    }
    void FadeIn()
    {
        m_InTtme += Time.deltaTime;
        if (m_FadIn > 0.0f && m_InTtme > 0.1f)
        {
            m_FadIn -= 0.1f;
            m_Fade.color = new Color(0, 0, 0, m_FadIn);
            m_InTtme = 0;
        }
        else if (m_FadIn < 0.0f)
        {
            m_InTtme = 0;
            m_FadIn = 0.0f;
            m_Fade.gameObject.SetActive(false);
        }
    }
}
