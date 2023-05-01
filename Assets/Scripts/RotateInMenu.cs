using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInMenu : MonoBehaviour
{
    [SerializeField]
    private float minRotationSpeed = 0.005f;

    [SerializeField]
    private float maxRotationSpeed = 1.2f;

    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.timeScale);
    }
}
