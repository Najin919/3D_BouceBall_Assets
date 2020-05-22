using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public GameObject m_Ball;

    private bool m_BallT = false;   //공과 바닥이 충돌
    private float m_Speed = 15.0f;

    Title_Mgr TouchScreen;

    // Start is called before the first frame update
    void Start()
    {
        //TouchScreen = GameObject.Find("b_ButtonT").GetComponent<Title_Mgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_BallT == true && GameObject.Find("Title_Mgr").GetComponent<Title_Mgr>().b_ButtonT == true)
            m_Ball.transform.Translate(Vector3.up * m_Speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == m_Ball && TouchScreen == true)
        {
            m_BallT = true;
        }
    }
}
