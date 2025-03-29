using UnityEngine;
using UnityEngine.InputSystem;

public class TurnCamera : MonoBehaviour
{
    public float rotationSpeed = 100f;
    private float rotationInput = 0f;

    public void OnTurnPerformed(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<float>();
    }

    void Update()
    {
        if (rotationInput != 0)
        {
            float newYRotation = transform.eulerAngles.y + (rotationInput * rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, newYRotation, 0);
        }
    }
}
