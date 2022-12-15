using UnityEngine;

public class PlayerMoveModel
{
    public void PlayerPosMove(PlayerParamViewModel param, Vector3 orizinPos, Vector3 padValue)
    {
        orizinPos.x += padValue.x;
        orizinPos.z += padValue.y;
        param.rb2d.velocity = orizinPos * param.moveSpeed * Time.deltaTime;
    }

    public void PointToViewMove(PlayerParamViewModel param, Transform orizinPos, Vector3 padValue)
    {
        var nowAngle = orizinPos.rotation.x;

        if (-padValue.y != 0)
        {
            if (0 < padValue.y)
            {
                if (0.5f <= nowAngle)
                {
                    orizinPos.Rotate(padValue.x, 0f, padValue.z);
                }
            }
            else
            {
                if (nowAngle <= 0.5)
                {
                    orizinPos.Rotate(padValue.x, 0f, padValue.z);
                }
            }
        }
    }

}

public class PlayerParamViewModel
{
    public float moveSpeed;
    public Rigidbody rb2d;
}
