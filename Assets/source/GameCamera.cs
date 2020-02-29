using UnityEngine;

public enum CameraMode
{
    NORMAl,
    SIDE,
    BACK,
    WIN
}

public class GameCamera : MonoBehaviour
{
    public Camera referenceNormal;
    public Camera referenceSide;
    public Camera referenceBack;
    public Camera referenceWin;

    public CameraMode mode;

    void Update()
    {
        Camera target = null;

        switch (mode)
        {
            case CameraMode.NORMAl:
                target = referenceNormal;
                break;
            case CameraMode.SIDE:
                target = referenceSide;
                break;
            case CameraMode.BACK:
                target = referenceBack;
                break;
            case CameraMode.WIN:
                target = referenceWin;
                break;
        }

        transform.position = Vector3.Lerp(transform.position, target.transform.position, 2f * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, 2f * Time.deltaTime);
    }
}