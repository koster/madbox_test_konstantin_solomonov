using UnityEngine;

public class ObstaclePendulum : MonoBehaviour
{
    public float apm = 2f;
    public float speed = 1f;
    public bool flip;

    Vector3 origin;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        origin = transform.position;

        if (flip)
            transform.position = origin + Vector3.right * apm;
        else
            transform.position = origin + Vector3.left * apm;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(origin + Vector3.right * (Mathf.Sin(Time.time * speed) * apm));
    }
}