using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            Main.instance.Loss();
    }
}