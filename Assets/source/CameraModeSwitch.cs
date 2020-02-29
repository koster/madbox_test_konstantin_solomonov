using UnityEngine;

public class CameraModeSwitch : MonoBehaviour
{
    public CameraMode mode = CameraMode.NORMAl;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Main.instance.gameCamera.mode = mode;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Main.instance.gameCamera.mode = CameraMode.NORMAl;
    }
}