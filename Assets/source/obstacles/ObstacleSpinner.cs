using System;
using UnityEngine;

public class ObstacleSpinner : Obstacle
{
    const float spinTime = 3f;
    const float spinInterval = 4f;

    public bool flip;

    float clock;

    void Start()
    {
        clock = spinInterval;
    }

    void Update()
    {
        clock += Time.deltaTime;

        if (clock > spinInterval)
            iTween.RotateAdd(gameObject, iTween.Hash(
                "amount", GetRotation(),
                "easetype", iTween.EaseType.easeOutSine,
                "time", spinTime
            ));
    }

    Vector3 GetRotation()
    {
        if (flip)
            return new Vector3(0f, -90f, 0f);
        return new Vector3(0f, 90f, 0f);
    }
}