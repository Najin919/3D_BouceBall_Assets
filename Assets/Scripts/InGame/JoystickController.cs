using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
    public static JoystickController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<JoystickController>();

                if(instance == null)
                {
                    var instanceContainer = new GameObject("JoystickController");
                    instance = instanceContainer.AddComponent<JoystickController>();
                }
            }
            return instance;
        }
    }

    private static JoystickController instance;

    public GameObject smallStick;
    public GameObject bGStick;
    Vector3 JoystickFirstPosition;
    public Vector3 joyVec;
    float stickRadius;

    // Start is called before the first frame update
    void Start()
    {
        stickRadius = bGStick.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    public void PointDown()
    {
        bGStick.gameObject.SetActive(true);
        bGStick.transform.position = Input.mousePosition;
        smallStick.transform.position = Input.mousePosition;
        JoystickFirstPosition = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - JoystickFirstPosition).normalized;

        float stickDistance = Vector3.Distance(DragPosition, JoystickFirstPosition);

        if(stickDistance < stickRadius)
        {
            smallStick.transform.position = JoystickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            smallStick.transform.position = JoystickFirstPosition + joyVec * stickRadius;
        }
    }

    public void Drop()
    {
        bGStick.gameObject.SetActive(false);
        joyVec = Vector3.zero;
        bGStick.transform.position = JoystickFirstPosition;
        smallStick.transform.position = JoystickFirstPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
