using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float mouseSensitivity = 800f;
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
        yaw += mouseX * mouseSensitivity * Time.deltaTime;
        pitch -= mouseY * mouseSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, clampMin, clampMax);

        //calcolo la rotazione orizzontale
        Quaternion yawRotation = Quaternion.Euler(0, yaw, 0);

        //calcolo la rotazione verticale
        Quaternion pitchRotation = Quaternion.Euler(pitch, 0, 0);

        //calcolo il finalOffset
        Vector3 finalOffset = pitchRotation * (yawRotation * offset);

        //fix per camera sotto il terreno
        Vector3 cameraPos = target.position + finalOffset;

        if (cameraPos.y < target.position.y + terrainOffset)
        {
            cameraPos.y = target.position.y + terrainOffset;
        }

        //posiziono la camera
        cam.transform.position = cameraPos;
        cam.transform.LookAt(target.position);
    }
}