using System;
using UnityEngine;

public class ObstaclePendulum : MonoBehaviour
{
    public float apm = 2f;
    public float speed = 1f;
    
    Vector3 origin;
    new Rigidbody rigidbody;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Main.instance.Loss();
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        origin = transform.position;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(origin + Vector3.right * (Mathf.Sin(Time.time * speed) * apm));
    }
}