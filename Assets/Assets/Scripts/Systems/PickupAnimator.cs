using UnityEngine;

public class PickupAnimator : MonoBehaviour
{
    [Header("Animation Settings")]
    [SerializeField] private float floatAmplitude = 0.5f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float timeOffset = 0f;


    private float originalY;
    private Vector3 tempPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Store the original Y position of the object
        originalY = transform.position.y;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave
        // Time.time continuously increases, Mathf.Sin produces a value between -1 and 1
        tempPos = transform.position;
        tempPos.y = originalY + (Mathf.Sin((speed * Time.time) + timeOffset) * floatAmplitude);
        transform.position = tempPos;
    }
}