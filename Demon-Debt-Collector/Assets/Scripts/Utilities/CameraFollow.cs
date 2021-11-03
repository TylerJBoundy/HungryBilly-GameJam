using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Variables")]
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.3f;

    [SerializeField] private float zoom = -10;

    [Header("Constraints")]
    [SerializeField] private float minX, maxX, minY, maxY;

    private Vector3 velocity = Vector3.zero;

    public Transform Target => target;

    //Used in edittor for better camera positioning settings.
    private void OnValidate() => transform.position = new Vector3(transform.position.x, transform.position.y, zoom);

    private void Update()
    {
        if (target != null) // if the target exists, set camera position relative to variables.
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, zoom));
            Vector3 desiredPosition = transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), zoom);
        }
    }

    /// <summary>
    /// Sets target value.
    /// </summary>
    /// <param name="newTarget">The new target to be set.</param>
    public void SetTarget(Transform newTarget) => target = newTarget;
}
