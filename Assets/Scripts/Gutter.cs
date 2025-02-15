using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody)
    {
        // we first get the rigidbody of the ball
        // and store it in a local variable ballRigidBody
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // We store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // It is important to reset the linear AND angular velocity
        // This is because the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // Now we add force in the forward direction of the gutter
        // We use the cached velocity magnitude to keep it a little realistic
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}