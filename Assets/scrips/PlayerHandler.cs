using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    private Camera mainCamera;     
      // reference to our model
    public Transform Model;

    [Range(20f,80f)]
    public float rotationSpeed= 20f;
      // reference to our animator      
    private Animator Anim; 
      // storing input direction

     private Vector3 StickDirection; 
        void Start()
    {   
       // Collect references here

       mainCamera = Camera.main;
       Anim=Model.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reaing WASD input here
        StickDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        HandleInputData();
        //We handle rotation to face stick direction, relative to camera
        HandleStandardLocomotionRotation();

    }
       
       private void HandleStandardLocomotionRotation( ) {

        Vector3 rotationOffSet = mainCamera.transform.TransformDirection(StickDirection);
        rotationOffSet.y = 0;
        Model.forward =Vector3.Lerp(Model.forward, rotationOffSet, Time.deltaTime*rotationSpeed); 
        //lerp used to smooth the current rotation to the target rotationOffset,
        
       }

    private void HandleInputData() {

        //using keyboard and pressing a diagonal direction you could reach a magnitude of 1.4 so we clamp it
        Anim.SetFloat("Speed", Vector3.ClampMagnitude(StickDirection,1).magnitude);       
    }
}
