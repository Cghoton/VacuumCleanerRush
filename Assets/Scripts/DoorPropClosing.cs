using UnityEngine;

public class DoorPropClosing : MonoBehaviour
{
    private new HingeJoint2D hingeJoint;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        if (hingeJoint.limitState == JointLimitState2D.UpperLimit)
        {
            hingeJoint.motor = new JointMotor2D { motorSpeed = -500f, maxMotorTorque = hingeJoint.motor.maxMotorTorque };
        }
        else
        {
            hingeJoint.motor = new JointMotor2D { motorSpeed = 0f, maxMotorTorque = hingeJoint.motor.maxMotorTorque };
        }
    }
}
