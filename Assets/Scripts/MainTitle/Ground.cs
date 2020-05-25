using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public GameObject m_Ball;

    public bool m_BallT = false;   //공과 바닥이 충돌
    private float m_Speed = 15.0f;

    public GameObject Title_Mgr;
    private Title_Mgr titlemgr;

    // Start is called before the first frame update
    void Start()
    {
        titlemgr = Title_Mgr.GetComponent<Title_Mgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_BallT == true)
            m_Ball.transform.Translate(Vector3.up * m_Speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == m_Ball && titlemgr.m_ButtonT == true)
        {
            m_BallT = true;
        }
    }
}
