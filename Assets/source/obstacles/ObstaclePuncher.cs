using UnityEngine;

public class ObstaclePuncher : Obstacle
{
    public const float timeIn = 0.5f;
    public const float timeOut = 1f;
    public const float flipTime = 1.2f;

    public bool state;

    float clock;

    void Start()
    {
        if (state)
            transform.position = GetPositionRaised();
        else
            transform.position = GetPositionHit();

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
            iTween.MoveTo(gameObject, iTween.Hash(
                "position", GetPositionHit(),
                "easetype", iTween.EaseType.easeOutBounce,
                "time", timeIn
            ));
        else
            iTween.MoveTo(gameObject, iTween.Hash(
                "position", GetPositionRaised(),
                "easetype", iTween.EaseType.easeOutBack,
                "time", timeOut
            ));

        state = !state;
    }

    Vector3 GetPositionHit()
    {
        var tp = transform.position;

        tp.y = 0;

        return tp;
    }

    Vector3 GetPositionRaised()
    {
        var tp = transform.position;

        tp.y = 5f;

        return tp;
    }
}