using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float restAngle = 0f;
    [SerializeField] float pressedAngle = 45f;

    [SerializeField] float motorSpeed = 1000f;
    [SerializeField] float maxMotorTorque = 1000f;

    [SerializeField] string inputAction = "RFLIPPER";

    HingeJoint hinge;
    JointMotor motor;

    void Awake()
    {
        hinge = GetComponent<HingeJoint>();

        hinge.useMotor = true;
        hinge.useLimits = true;

        JointLimits limits = hinge.limits;
        limits.min = restAngle;
        limits.max = pressedAngle;
        hinge.limits = limits;

        motor = hinge.motor;
        motor.force = maxMotorTorque;
    }

    void FixedUpdate()
    {
        motor.targetVelocity = Input.GetButton(inputAction)
            ? motorSpeed
            : (-motorSpeed * 0.5f);

        hinge.motor = motor;
    }
}
