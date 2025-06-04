using UnityEngine;
using UnityEngine.XR;

public class GrabWithLeftHand : MonoBehaviour
{
    public OculusInputHandler inputHandler;  // Referencia al input de la mano izquierda
    public Transform grabPoint;              // Donde se coloca el objeto agarrado

    private GameObject currentObjectInRange;
    private GameObject grabbedObject;
    private Rigidbody grabbedRigidbody;

    private Vector3 lastPosition;
    private Vector3 velocity;
    private Vector3 angularVelocity;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            currentObjectInRange = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grabbable") && currentObjectInRange == other.gameObject)
        {
            currentObjectInRange = null;
        }
    }

    void Update()
    {
        // Calcular velocidad de movimiento de la mano (basado en grabPoint)
        velocity = (grabPoint.position - lastPosition) / Time.deltaTime;
        angularVelocity = grabPoint.rotation.eulerAngles - lastPositionRotation;

        lastPosition = grabPoint.position;
        lastPositionRotation = grabPoint.rotation.eulerAngles;

        if (inputHandler.leftGripButtonPressed)
        {
            if (grabbedObject == null && currentObjectInRange != null)
            {
                GrabObject(currentObjectInRange);
            }
        }
        else
        {
            if (grabbedObject != null)
            {
                ReleaseObject();
            }
        }
    }

    Vector3 lastPositionRotation;

    void GrabObject(GameObject obj)
    {
        grabbedObject = obj;
        grabbedObject.transform.SetParent(grabPoint);
        grabbedObject.transform.localPosition = Vector3.zero;
        grabbedObject.transform.localRotation = Quaternion.identity;

        grabbedRigidbody = obj.GetComponent<Rigidbody>();
        if (grabbedRigidbody != null)
        {
            grabbedRigidbody.isKinematic = true;
        }
    }

    void ReleaseObject()
    {
        if (grabbedObject == null) return;

        if (grabbedRigidbody != null)
        {
            grabbedRigidbody.isKinematic = false;
            grabbedRigidbody.velocity = velocity;
            grabbedRigidbody.angularVelocity = angularVelocity * Mathf.Deg2Rad;
        }

        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
        grabbedRigidbody = null;
    }
}