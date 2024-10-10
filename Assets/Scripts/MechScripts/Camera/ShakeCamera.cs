using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeIntensity = 0.1f;

    private Vector3 initialPosition;
    private float currentShakeDuration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShakeTheCamera();
        }

        if (currentShakeDuration > 0)
        {
            //Shake camera by randomly offsetting it inside of a circle
            Vector3 randomOffSet = Random.insideUnitSphere * shakeIntensity;
            transform.localPosition = initialPosition + randomOffSet;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = initialPosition;
        }
    }

    public void ShakeTheCamera()
    {
        currentShakeDuration = shakeDuration;
    }
}
