using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    private Vector3 _offset;
    private void Awake() => _offset = transform.position - target.position;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }

    private void Update()
    {
        // Raycast form the camera to the target to see if there are any obstacles in the way
        RaycastHit hit;
        if (Physics.Linecast(transform.position, target.position, out hit))
        {
            Debug.DrawLine(transform.position, target.position, Color.green);
            // If there is an obstacle, move the camera to the point of impact
            if (hit.transform != target)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
        }
    }
}
