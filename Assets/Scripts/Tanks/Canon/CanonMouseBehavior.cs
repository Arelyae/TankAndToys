using UnityEngine;

public class CanonMouseBehavior : MonoBehaviour
{
    public Camera mainCamera;
    Vector3 targetPosition;

    [SerializeField] CanonFunctionTemplate canonFunction;

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
        GetMouse();
        FaceTargetPositon(targetPosition, transform);
    }   

    public void GetMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // Set the correct depth

        targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);
    }

    public  void FaceTargetPositon(Vector3 targetPosition, Transform t)
    {
        // Calculate the direction from the object to the mouse position
        Vector3 direction = targetPosition - t.position;

        // Rotate to face the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate angle to the mouse
        t.rotation = Quaternion.Euler(0, 0, angle); // Apply rotation in 2D space

    }

}
