using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float clampMin = -60f;
    [SerializeField] private float clampMax = 60f;
    private float pitch;
    private float yaw;
    private Camera cam;
    private const float terrainOffset = 0.5f;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        //prendo in input
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");

        //aggiorno yaw e pitch
        yaw += mouseX * mouseSensitivity;
        pitch -= mouseY * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, clampMin, clampMax);

        //calcolo la rotazione
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        //calcolo il finalOffset
        Vector3 finalOffset = rotation * offset;

        if (target == null) return;

        Vector3 cameraPos = target.position + finalOffset;

        //fix per camera sotto il terreno
        if (cameraPos.y < target.position.y + terrainOffset)
        {
            cameraPos.y = target.position.y + terrainOffset;
        }

        //posiziono la camera
        cam.transform.position = cameraPos;
        cam.transform.LookAt(target.position);
    }
}