using UnityEngine;

public class CoinRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;

    private void Update()
    {
        gameObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}