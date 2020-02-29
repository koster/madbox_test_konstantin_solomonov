using UnityEngine;

public class Arch : MonoBehaviour
{
    public Vector3 off;
    public float aoff;
    public float r = 1f;

    public bool inverse;

    bool isApplied;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isApplied = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isApplied = false;
        }
    }

    void OnDrawGizmos()
    {
        for (var i = 0; i < 25; i++)
        {
            var lDirection = GetPoint(i);
            Gizmos.color = Color.Lerp(Color.white, Color.red, i / 25f);
            Gizmos.DrawSphere(lDirection, 0.1f);
        }
    }

    Vector3 GetPoint(int i)
    {
        var angle = aoff + 270f + i / 25f * 90f;
        var lDirection = transform.position + off + new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0f, Mathf.Cos(Mathf.Deg2Rad * angle)) * r;
        return lDirection;
    }

    int GetClosestPointIndex(Vector3 pos)
    {
        var n = 0;
        var md = float.MaxValue;
        
        for (var i = 0; i < 26; i++)
        {
            var d = Vector3.Distance(pos, GetPoint(i));

            if (d < md)
            {
                n = i;
                md = d;
            }
        }

        return n;
    }

    void Update()
    {
        if (isApplied)
        {
            var pt = Main.instance.pc.transform;
            var ptc = pt.position;
            var n = GetClosestPointIndex(ptc);
            
            if (inverse)
            {
                var a = GetPoint(n - 1) - GetPoint(n + 1);
                pt.forward = a;
            }
            else
            {
                var a = GetPoint(n + 1) - GetPoint(n - 1);
                pt.forward = a;
            }
        }
    }
}