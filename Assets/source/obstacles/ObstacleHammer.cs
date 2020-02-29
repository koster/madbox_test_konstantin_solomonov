using UnityEngine;

public class ObstacleHammer : Obstacle
{
    public const float timeIn = 0.5f;
    public const float timeOut = 1f;
    public const float flipTime = 1.2f;

    public bool state;
    public bool flip;

    float clock;

    void Start()
    {
        if (state)
            transform.rotation = Quaternion.Euler(GetRotationRaised());
        else
            transform.rotation = Quaternion.Euler(GetRotationHit());

        // start with a hit
        clock = flipTime;
    }

    void Update()
    {
        clock += Time.deltaTime;

        if (clock > flipTime)
        {
            Flip();
            clock = 0;
        }
    }

    void Flip()
    {
        if (state)
            iTween.RotateTo(gameObject, iTween.Hash(
                "rotation", GetRotationHit(),
                "easetype", iTween.EaseType.easeOutBounce,
                "time", timeIn
            ));
        else
            iTween.RotateTo(gameObject, iTween.Hash(
                "rotation", GetRotationRaised(),
                "easetype", iTween.EaseType.easeOutCirc,
                "time", timeOut
            ));

        state = !state;
    }

    Vector3 GetRotationHit()
    {
        if (flip)
            return new Vector3(0f, 0f, -180f);
        return new Vector3(0f, 0f, 0f);
    }

    Vector3 GetRotationRaised()
    {
        if (flip)
            return new Vector3(0f, 0f, -90f);
        return new Vector3(0f, 0f, -90f);
    }
}