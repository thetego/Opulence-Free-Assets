using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputReceiver))]
public class Engine : MonoBehaviour
{
    #region 
    [Header("Wheels")]
    [Space]
    [SerializeField] private WheelCollider front_left;
    [SerializeField] private WheelCollider front_right;
    [SerializeField] private WheelCollider rear_left;
    [SerializeField] private WheelCollider rear_right;
    
    #endregion
    #region 
    [Header("Wheels(Mesh)")]
    [Space]
    [SerializeField] private GameObject front_left_mesh;
    [SerializeField] private GameObject front_right_mesh;
    [SerializeField] private GameObject rear_left_mesh;
    [SerializeField] private GameObject rear_right_mesh;
    
    #endregion
    #region 
    private enum TorqType
    {
        FWD,
        AWD,
        RWD,
        FOURWD
    }
    [SerializeField] private TorqType _Type;
    #endregion
    #region 
    [Header("Steering")]
    [Space]
    [SerializeField] private float maxSteer;
    #endregion
    #region 
    [Header("Speed")]
    [Space]
    [SerializeField] private float maxSpeed;
    #endregion
    #region 
    [SerializeField] private GameObject centreofMass;
    #endregion
    Rigidbody rb;
    private void Awake()
    {
        //rb=GetComponent<Rigidbody>();
        //rb.centerOfMass = centreofMass.transform.position;
    }
    private void LateUpdate()
    {
        UpdatePose(front_left, front_left_mesh.transform);
        UpdatePose(front_right, front_right_mesh.transform);
        UpdatePose(rear_left, rear_left_mesh.transform);
        UpdatePose(rear_right, rear_right_mesh.transform);
    }
    void UpdatePose(WheelCollider collider, Transform _transform)
    {
        Vector3 pos = _transform.position;
        Quaternion quat = _transform.rotation;

        collider.GetWorldPose(out pos, out quat);
        
        //_transform.transform.position = pos;
        _transform.transform.rotation = quat;

    }
    public void Gas (float direction) 
    {
        switch (_Type){
            case TorqType.FOURWD:
                rear_left.motorTorque = direction * maxSpeed;
                rear_right.motorTorque = direction * maxSpeed;
                front_left.motorTorque = direction * maxSpeed;
                front_right.motorTorque = direction * maxSpeed;
                break;
            case TorqType.RWD:
                rear_left.motorTorque = direction * maxSpeed;
                rear_right.motorTorque = direction * maxSpeed;
                break;
            case TorqType.FWD:
                front_left.motorTorque = direction * maxSpeed;
                front_right.motorTorque = direction * maxSpeed;
                break;
            case TorqType.AWD:
                rear_left.motorTorque = direction * maxSpeed;
                rear_right.motorTorque = direction * maxSpeed;
                break;
        }
    }

    public void Brake (float brakePower)
    {
        
    }
    public void Steer (float direction)
    {
        front_left.steerAngle = direction* maxSteer;
        front_right.steerAngle = direction* maxSteer;
    }
}
