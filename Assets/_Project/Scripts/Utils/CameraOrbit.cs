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

        cam.transform.position = target.position + finalOffset; //metto la camera dietro il player e applico l'offset ruotato
        cam.transform.LookAt(target.position);    //uso il lookAt per far guardare la camera verso il player.
    }
}