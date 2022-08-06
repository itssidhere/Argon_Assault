using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;
    [SerializeField] float xRange = 8f;
    [SerializeField] float yRange = 4f;
    float xThrow, yThrow;
    [SerializeField] float posPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;

    [SerializeField] float controlRollFactor = -30f;

    [SerializeField] float posYawFactor = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOfsset = yThrow * ySpeed * Time.deltaTime;
        float rawX = transform.localPosition.x + xOffset;
        float rawY = transform.localPosition.y + yOfsset;
        float clampedX = Mathf.Clamp(rawX, -xRange, xRange);
        float clampedY = Mathf.Clamp(rawY, -yRange, yRange);
        transform.localPosition = new Vector3(clampedX, clampedY, transform.localPosition.z);
    }

    private void ProcessRotation() {
        float pitch = (transform.localPosition.y * posPitchFactor ) + ( yThrow * controlPitchFactor ) ;
        float yaw = (transform.localPosition.x * posYawFactor);
        float roll = (xThrow * controlRollFactor);
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    
    }
}
