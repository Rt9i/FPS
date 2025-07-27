using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] Canvas canva;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera != null)
        {
            // This sets the UI to face the camera directly
            canva.transform.forward = mainCamera.transform.forward;
        }
    }
}
