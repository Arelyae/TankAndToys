using UnityEngine;

public class CanonBehavior : MonoBehaviour
{
    public Transform referenceTransform; 
    public Camera mainCamera;           

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Use the main camera if none is assigned
            if (mainCamera == null)
            {
                Debug.LogError("No camera found. Assign one in the inspector.");
            }
        }
    }

    void Update()
    {
        FollowReferenceTransform();
        FaceMousePosition();
    }

    // Keeps the object at the same position as the reference transform
    private void FollowReferenceTransform()
    {
        if (referenceTransform != null)
        {
            transform.position = referenceTransform.position; // Snap to the referenced transform's position
        }
    }

    // Makes the object face the mouse position
    private void FaceMousePosition()
    {
        if (mainCamera == null) return;

        // Get the mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // Set the correct depth

        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the object to the mouse position
        Vector3 direction = worldMousePosition - transform.position;

        // Normalize the direction to avoid scaling issues
        direction.z = 0; // Ensure rotation stays in 2D
        direction.Normalize();

        // Rotate to face the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate angle to the mouse
        transform.rotation = Quaternion.Euler(0, 0, angle); // Apply rotation in 2D space
    }
}
