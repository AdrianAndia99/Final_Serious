using UnityEngine;

public class RightJoystickCameraRotation : MonoBehaviour
{
    public OculusInputHandler inputHandler; // Referencia a tu script de inputs
    public float rotationSpeed = 90f;       // grados por segundo

    float pitch = 0f;  // rotación vertical acumulada (opcional)
    public float pitchLimit = 80f; // límite para no girar demasiado arriba/abajo

    void Update()
    {
        Vector2 rightInput = inputHandler.rightJoystickInput;

        // Rotación horizontal (yaw) alrededor del eje Y
        float yaw = rightInput.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, yaw, 0);

        // Rotación vertical (pitch) limitada
        pitch -= rightInput.y * rotationSpeed * Time.deltaTime; // invertir para sentido natural
        pitch = Mathf.Clamp(pitch, -pitchLimit, pitchLimit);

        // Aplicar rotación vertical (pitch) localmente en X
        Vector3 currentEuler = transform.localEulerAngles;
        currentEuler.x = pitch;
        transform.localEulerAngles = currentEuler;
    }
}