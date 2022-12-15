using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public delegate void OnLeftStickDownHandler();
    public event OnLeftStickDownHandler OnLeftStickDown;
    public delegate void OnRightStickDownHandler();
    public event OnRightStickDownHandler OnRightStickDown;
    public delegate void OnLeftTriggerDownHandler();
    public event OnLeftTriggerDownHandler OnLeftTriggerDown;

    public void LeftStickDown()
    {
        OnLeftStickDown?.Invoke();
    }

    public void RightStickDown()
    {
        OnRightStickDown?.Invoke();
    }

    public void LeftTriggerDown()
    {
        OnLeftTriggerDown?.Invoke();
    }
}
