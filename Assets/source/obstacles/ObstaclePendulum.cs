using UnityEngine;

public class ObstaclePendulum : Obstacle
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

        transform.position = origin + Vector3.left * apm;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(origin + transform.right * (GetProgress() * apm));
    }

    float GetProgress()
    {
        if (flip)
            return Mathf.Cos(Time.time * speed);
        return Mathf.Sin(Time.time * speed);
    }
}