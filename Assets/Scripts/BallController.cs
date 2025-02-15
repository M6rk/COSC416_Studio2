using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    //private InputManager inputManager;
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private InputManager inputManager;

    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        ballRB = GetComponent<Rigidbody>();
        //inputManager = FindObjectOfType<InputManager>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;
    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }
}