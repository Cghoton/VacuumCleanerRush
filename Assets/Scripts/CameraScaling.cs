using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    public float baseScreenWidth = 720f;
    public float baseScreenHeight = 1280f;


    [SerializeField] private float targetWidth = 1080f;
    [SerializeField] private float pixelsPerUnit = 100f;

    [SerializeField]
    private GameObject BackGround;

    [SerializeField]
    private Vector2 colorPosition;

    private Camera mainCamera;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        ChangeBackgroundColor();
        ScalingCamera();
    }

    private void ChangeBackgroundColor()
    {
        mainCamera.backgroundColor = BackGround.GetComponent<SpriteRenderer>().color / 2.6f;
    }

    private void ScalingCamera()
    {
        float targetAspect = 16f / 9f; // The desired aspect ratio
        float targetHeight = 10f; // The desired vertical size of the camera's view
        float currentAspect = Screen.width * 1.0f / Screen.height;

        if (currentAspect > targetAspect)
        {
            mainCamera.orthographicSize = targetHeight / 2f;
        }
        else
        {
            mainCamera.orthographicSize = (targetHeight / currentAspect) / 2f;
        }
    }
}

