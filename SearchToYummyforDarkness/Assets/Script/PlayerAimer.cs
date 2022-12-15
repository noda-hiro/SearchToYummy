using UnityEngine;

public class PlayerAimer : MonoBehaviour
{
    [SerializeField]
    private Transform orizinPos;
    [SerializeField]
    private Transform targetPos;
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, -0.999f)]
    public float minYAngle = 0.5f;

    void Start()
    {
        if (orizinPos == null) orizinPos = transform.parent;
        if (targetPos == null) targetPos = transform;
    }

    void Update()
    {
        Vector3 vec = orizinPos.position - targetPos.position;
        float YRote = Input.GetAxis("Mouse Y");
        orizinPos.transform.Rotate(0, YRote, 0);

        float nowAngle = targetPos.transform.localRotation.x;
        if (-YRote != 0)
        {
            if (0 < YRote)
            {
                if (minYAngle <= nowAngle)
                {
                    targetPos.transform.Rotate(-YRote, 0, 0);
                }
            }
            else
            {
                if (nowAngle <= maxYAngle)
                {
                    targetPos.transform.Rotate(-YRote, 0, 0);
                }
            }
            orizinPos.Rotate(0f, targetPos.position.y, 0f);
        }

    }
}
