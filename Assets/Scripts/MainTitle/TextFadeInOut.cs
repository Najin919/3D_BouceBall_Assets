using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour
{
    public enum STATE
    {
        CREATE, SHOW, FADEOUT, INVISIBLE, FADEIN
    }
    public STATE m_State = STATE.CREATE;// 현재 상태
    public Text m_StartKey;   // 사용할 텍스트
    public float m_ShowTime = 1f;       // 보여주는 시간
    public float m_StartWaitTime = 0.5f;  // 1초뒤에 시작하도록 딜레이

    void Start()
    {
        ChangeState(STATE.SHOW);
    }

    //오브젝트 삭제 시 모든 코루틴 종료
    private void OnDestroy()
    {
        StopAllCoroutines();
        //m_StartKey.StopAllCoroutines();        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Start");
            Destroy(m_StartKey);
        }
    }

    IEnumerator DelayChangeState(STATE s, float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeState(s);
    }

    void ChangeState(STATE s)
    {
        if (m_State == s) return;
        m_State = s;
        switch (m_State)
        {
            case STATE.CREATE:
                break;
            case STATE.SHOW:
                StartCoroutine(DelayChangeState(STATE.FADEOUT, m_ShowTime));
                break;
            case STATE.FADEOUT:
                StartCoroutine(DelayChangeState(STATE.INVISIBLE, m_StartWaitTime));
                m_StartKey.CrossFadeAlpha(0f, 1f, false);
                break;
            case STATE.INVISIBLE:
                StartCoroutine(DelayChangeState(STATE.FADEIN, m_ShowTime));
                break;
            case STATE.FADEIN:
                StartCoroutine(DelayChangeState(STATE.SHOW, m_StartWaitTime));
                m_StartKey.CrossFadeAlpha(1f, 1f, false);

                break;
        }
    }

}
