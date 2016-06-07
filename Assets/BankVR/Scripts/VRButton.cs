using UnityEngine;
using System;

public class VRButton : MonoBehaviour {

    public ButtonHolder buttonHolder;
    public Transform target;
    public Transform targetPressed;
    new Rigidbody rigidbody;

    [Range(0f, 2f)]
    public float maxDistanceThresholdPressed = 0.1f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        DoPosition();
        DoRotation();
        CheckIfPressed();
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void DoPosition()
    {
        // Get vector from current position to parent's position
        Vector3 forceToParentPosition = target.position - transform.position;

        // Divide by fixed timestep (default is 0.2f)
        // so that we will get where we want to go in one step
        forceToParentPosition = forceToParentPosition / Time.fixedDeltaTime;

        // Subtract existing velocity
        forceToParentPosition = forceToParentPosition - rigidbody.velocity;

        // Add force as a VelocityChange, so it ignores mass, and effectively just sets our velocity
        rigidbody.AddForce(forceToParentPosition, ForceMode.VelocityChange);
    }

    void DoRotation()
    {
        rigidbody.rotation = target.rotation;
    }

    void CheckIfPressed()
    {
        var distanceToPressedTarget = Vector3.Distance(transform.position, targetPressed.position);
        Debug.Log(distanceToPressedTarget);
        if (distanceToPressedTarget < maxDistanceThresholdPressed)
        {
            OnPressed();
        }
    }

    void OnPressed() {
        Debug.Log("PRESSED");
        buttonHolder.OnButtonPress();
    }
}
