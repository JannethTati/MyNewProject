using UnityEngine;

public class HeartFloat : MonoBehaviour
{
    public float speed = 2f;
    public float height = 0.25f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * speed) * height;
    }
}
