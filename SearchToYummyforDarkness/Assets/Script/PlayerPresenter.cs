using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPresenter : MonoBehaviour
{
    private PlayerMoveModel moveModel;
    private PlayerParamViewModel paramViewModel;
    private Gamepad currentPad;

    [SerializeField]
    private PlayerParameter playerParameter;
    [SerializeField]
    private PlayerView playerView;


    private void Awake()
    {

        moveModel = new PlayerMoveModel();
        paramViewModel = new PlayerParamViewModel
        {
            moveSpeed = playerParameter.speed,
            rb2d = GetComponent<Rigidbody>(),
        };

        playerView.OnLeftStickDown += LeftStickDownNotifier;
        playerView.OnRightStickDown += RightStickDownNotifier;
    }

    public void LeftStickDownNotifier()
    {
        var stickValue = currentPad.leftStick.ReadValue();
        moveModel.PlayerPosMove(paramViewModel, this.transform.position, stickValue);
    }

    public void RightStickDownNotifier()
    {
        var stickValue = currentPad.rightStick.ReadValue();
        moveModel.PointToViewMove(paramViewModel, this.transform, stickValue);
    }

}
