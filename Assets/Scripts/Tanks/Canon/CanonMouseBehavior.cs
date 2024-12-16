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
        canonFunction.FaceTargetPositon(targetPosition, transform);
    }   

    public void GetMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(mainCamera.transform.position.z - transform.position.z); // Set the correct depth

        targetPosition = mainCamera.ScreenToWorldPoint(mousePosition);
    }

}
