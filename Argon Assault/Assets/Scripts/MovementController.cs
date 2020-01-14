using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementController : MonoBehaviour
{
    [Header("General")]

    [Tooltip("In m/s")]
    [SerializeField]
    float ControlSpeed = 15f;

    [Header("Position based")]

    [Tooltip("In meters")]
    [SerializeField]
    float xLocalPositionLimit = 4f;

    [Tooltip("In meters")]
    [SerializeField]
    float yLocalPositionLimit = 3.5f;

    [Tooltip("In Euler degrees")]
    [SerializeField]
    float maxPitchFromPosition = 15f;

    [Tooltip("In Euler degrees")]
    [SerializeField]
    float maxYawFromPosition = 30f;

    [Tooltip("In Euler degrees")]
    [SerializeField]
    float rollFromPositionFactor = 0.6f;

    [Header("Control Throw based")]

    [Tooltip("In Euler degrees")]
    [SerializeField]
    float maxRollFromThrow = 20f;


    [Tooltip("In Euler degrees")]
    [SerializeField]
    float maxPitchFromThrow = 20f;

    private bool controlsDeactivated;


    // Update is called once per frame
    void Update()
    {
        if (controlsDeactivated)
        {
            return;
        }

        HandleInput();
    }

    private void HandleInput()
    {
        Translate();
        Rotate();
    }

    private void Translate()
    {
        var xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        var xOffset = xThrow * ControlSpeed * Time.deltaTime;
        var xLocal = transform.localPosition.x + xOffset;

        var yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        var yOffset = yThrow * ControlSpeed * Time.deltaTime;
        var yLocal = transform.localPosition.y;

        transform.localPosition = new Vector3(
            Mathf.Clamp(xLocal, -xLocalPositionLimit, xLocalPositionLimit),
            Mathf.Clamp(yLocal + yOffset, -yLocalPositionLimit, yLocalPositionLimit),
            transform.localPosition.z
            );
    }

    private void Rotate()
    {
        var rotationFromPosition = getRotationFromPosition();
        var rotationFromThrow = getRotationFromThrow();

        var rotation = rotationFromPosition + rotationFromThrow;

        transform.localRotation = Quaternion.Euler(rotation);
    }

    private Vector3 getRotationFromPosition()
    {
        var normalizedLocalY = transform.localPosition.y / yLocalPositionLimit;
        var pitchFromPosition = getPitchFromPosition();
        var yawFromPosition = getYawFromPosition();
        float rollFromPosition = getRollFromPosition(normalizedLocalY, yawFromPosition);

        return new Vector3(pitchFromPosition, yawFromPosition, rollFromPosition);
    }

    private float getRollFromPosition(float normalizedLocalY, float yawFromPosition)
    {
        return yawFromPosition * rollFromPositionFactor * -normalizedLocalY;
    }

    private float getYawFromPosition()
    {
        var yawFactor = maxYawFromPosition / xLocalPositionLimit;
        var yawFromPosition = transform.localPosition.x * yawFactor;
        return yawFromPosition;
    }

    private float getPitchFromPosition()
    {
        var pitchFactor = -maxPitchFromPosition / yLocalPositionLimit;
        var pitchFromPosition = transform.localPosition.y * pitchFactor;
        return pitchFromPosition;
    }

    private Vector3 getRotationFromThrow()
    {
        var xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        var rollFromThrow = xThrow * -maxRollFromThrow;

        var yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        var pitchFromThrow = yThrow * -maxPitchFromThrow;

        return new Vector3(pitchFromThrow, 0f, rollFromThrow);
    }

    public void OnCollisionTriggered()
    {
        controlsDeactivated = true;
    }
}
