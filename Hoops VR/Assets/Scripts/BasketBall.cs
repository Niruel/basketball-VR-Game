using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BasketBall : MonoBehaviour
{
    

   public  Rigidbody rb;

    public Transform mytarget;
  

     public float _angle=70f;
     public float _speed=4f;

    public Slider mySlider;

    

    private void Awake()
    {
        
       
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        _angle = 0f;
        
      
       
    }

    private void FixedUpdate()
    {
        PowerSlider();

       /* if (OVRInput.GetActiveController() == OVRInput.Controller.LTrackedRemote ||
    OVRInput.GetActiveController() == OVRInput.Controller.RTrackedRemote)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                _angle += Time.deltaTime * _speed;
            }
           
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                rb.useGravity = true;
                Launch();
                _angle = 0;
               
            }
        }*/

    }
    
    private void Launch()
    {
        // source and target positions
        Vector3 pos = transform.position;
        Vector3 target = mytarget.position;

        // distance between target and source
        float dist = Vector3.Distance(pos, target);
        Debug.Log(dist);    
        // rotate the object to face the target
        transform.LookAt(target);

        // calculate initival velocity required to land the ball on target using the
        float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * _angle * 2)));
        float Vy, Vz;   // y,z components of the initial velocity

        Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * _angle);
        Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * _angle);

        // create the velocity vector in local space
        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        //Vector3 localRot = new Vector3(x, 0, 0);

        // transform it to global vector
        Vector3 globalVelocity = transform.TransformVector(localVelocity);

        // launch the ball by setting its initial velocity
        rb.velocity = globalVelocity;
        rb.AddRelativeTorque(-globalVelocity*_speed); 


    }
    public void PowerSlider()
    {
        //slider updates
        mySlider.value = _angle;

       
    }

   




}
