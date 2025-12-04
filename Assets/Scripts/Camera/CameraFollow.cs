using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow Settings")]
    private Vector3 offset = new Vector3(0f, 0f, -30f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //target = Player.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);
    }
}
