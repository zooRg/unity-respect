using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header ("Controlling Settings")]
    public float horizontalScrollMultiplier;
    public float verticalScrollMultiplier;

    [Header("Transform Settings")]
    public Transform cameraTransform;

    public Transform verticalRotPivot;
    public Transform horizontalRotPivot;


    private float _prevRotX;
    private float _prevRotY;
    private Vector3 _startPointerCoord;

    private bool _pressed;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cameraTransform.LookAt(verticalRotPivot);

        if (Input.GetMouseButtonDown(0))
        {
            _startPointerCoord = Input.mousePosition;
            Debug.Log("PointerDown");
            _pressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            Debug.Log("PointerUp");
            _prevRotX = verticalRotPivot.localRotation.x;
            _prevRotY = verticalRotPivot.localRotation.y;
            
            _pressed = false;

        }

        if (_pressed)
        {
            verticalRotPivot.localRotation = Quaternion.Euler(0,  _prevRotY + verticalScrollMultiplier * Input.mousePosition.x - _startPointerCoord.x, 0);
            horizontalRotPivot.localRotation = Quaternion.Euler( _prevRotX -1 * horizontalScrollMultiplier * Input.mousePosition.y - _startPointerCoord.y,0,  0);
        }
    }
}
