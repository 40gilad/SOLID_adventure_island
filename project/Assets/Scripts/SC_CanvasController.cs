using UnityEngine;

public class SC_CanvasController : MonoBehaviour
{
    public Transform player; // Reference to Mario's transform

    private Vector3 initialRotation;

    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    void LateUpdate()
    {
        //transform.eulerAngles = new Vector3(initialRotation.x, initialRotation, eulerAngles.z);
    }
}
