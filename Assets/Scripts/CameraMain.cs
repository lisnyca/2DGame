using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public Transform target; 

    // Update is called once per frame
    void FixedUpdate()
    {
      transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
    }
}
