using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    /// <summary>
    /// PS4コントローラー左スティック入力関数
    /// </summary>
    /// <param name="context"></param>
    public void LeftStickMove(InputAction.CallbackContext context)
    {
        var stickValue = context.ReadValue<Vector2>();
        Debug.Log(stickValue);
        var moveValue = new Vector3(stickValue.x*speed
        *Time.deltaTime,0,stickValue.y *speed*Time.deltaTime);
        Debug.Log("aa");
        //アニメーション分岐処理

        switch(context.phase)
        {
            case InputActionPhase.Started:
            break;
            case InputActionPhase.Canceled:
            break;
            default :
            transform.forward = moveValue;
            break;
        }

        transform.position = transform.position +　moveValue;

    }

}
