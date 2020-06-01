using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public static MovingBall Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<MovingBall>();
                if(instance == null)
                {
                    var instanceCoutainer = new GameObject("MovingBall");
                    instance = instanceCoutainer.AddComponent<MovingBall>();
                }
            }
            return instance;
        }
    }
    private static MovingBall instance;

    Rigidbody rb;

    float Movespeed = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //rb.velocity = new Vector3(moveHorizontal * Movespeed, rb.velocity.y, moveVertical * Movespeed);   //방향키
       
        if(JoystickController.Instance.joyVec.x != 0 || JoystickController.Instance.joyVec.y !=0)
        {
            rb.velocity = new Vector3(JoystickController.Instance.joyVec.x* Movespeed, rb.velocity.y, JoystickController.Instance.joyVec.y* Movespeed);   //JoyVec의z값은 바뀌지 않음
            rb.rotation = Quaternion.LookRotation(new Vector3  (0, JoystickController.Instance.joyVec.y, 0));
        }
        //Debug.Log(JoystickController.Instance.joyVec.z);
    }

    void Update()
    {

    }
}
