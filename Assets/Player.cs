using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [SerializeField] float xRange = 4f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawX = transform.localPosition.x + xOffset;
        float clampedX = Mathf.Clamp(rawX, -xRange, xRange);
        transform.localPosition = new Vector3(clampedX, transform.localPosition.y, transform.localPosition.z);
    }
}
