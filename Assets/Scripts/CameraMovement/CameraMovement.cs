using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smoothSpeed = 0.125f;
    [SerializeField]
    private Vector2 min;
    [SerializeField]
    private Vector2 max;

    private void Awake()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position;

        targetPosition.z = transform.position.z;

        float clampedX = Mathf.Clamp(targetPosition.x, min.x, max.x);
        float clampedY = Mathf.Clamp(targetPosition.y, min.y, max.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, targetPosition.z);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        transform.position = smoothPosition;
    }
}
