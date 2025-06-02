using UnityEngine;

public class LeftJoystickMovement : MonoBehaviour
{
    public OculusInputHandler inputHandler;  // referencia a tu script que lee el input

    public float moveSpeed = 3f; // velocidad de movimiento

    void Update()
    {
        Vector2 input = inputHandler.leftJoystickInput;

        Vector3 moveDirection = Vector3.zero;

        // Asumiendo eje Y para adelante/atrás, X para izquierda/derecha
        if (input.y > 0.5f)
            moveDirection += Vector3.forward;   // adelante
        else if (input.y < -0.5f)
            moveDirection += Vector3.back;      // atrás

        if (input.x > 0.5f)
            moveDirection += Vector3.right;     // derecha
        else if (input.x < -0.5f)
            moveDirection += Vector3.left;      // izquierda

        moveDirection = moveDirection.normalized; // normalizar para no moverse más rápido en diagonal

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}