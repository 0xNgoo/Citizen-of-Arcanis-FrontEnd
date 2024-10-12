using UnityEngine;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // El personaje a seguir
    public float distance = 10f;  // Distancia de la c�mara al personaje
    public float height = 5f;  // Altura de la c�mara sobre el personaje
    public float rotationSpeed = 5f;  // Velocidad de rotaci�n de la c�mara
    public float zoomSpeed = 2f;  // Velocidad del zoom
    public float minZoom = 5f;  // Distancia m�nima del zoom
    public float maxZoom = 15f;  // Distancia m�xima del zoom

    private float currentZoom = 10f;
    private float currentRotation = 0f;

    void Update()
    {
        // Controlar el zoom con la rueda del rat�n
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Controlar la rotaci�n con el bot�n derecho del rat�n
        if (Input.GetMouseButton(1))
        {
            currentRotation += Input.GetAxis("Mouse X") * rotationSpeed;
        }

        // Actualizar la posici�n y rotaci�n de la c�mara
        Vector3 direction = new Vector3(0, height, -currentZoom);
        Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
        transform.position = target.position + rotation * direction;

        // Hacer que la c�mara siempre mire al personaje
        transform.LookAt(target.position);
    }
}

