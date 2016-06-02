using UnityEngine;
using System.Collections;

public class ViveTeleport : MonoBehaviour {

    public float rayLength = 100f;
    public bool isLeftController = false;
    public float heightModifier = 0f;

    public Transform cameraRig;
    public Transform head;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rayDirection = transform.forward * rayLength;

        Debug.DrawRay(transform.position, rayDirection, Color.red, 0.1f);

        Ray ray = new Ray(transform.position, rayDirection);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayDirection, out hit)) {
            // check if we hit a teleport spot
            TeleportSpot teleSpot = hit.collider.GetComponent<TeleportSpot>();

            if (teleSpot != null)
            {
                if (isLeftController)
                {
                    if (ViveInput.Instance.leftTriggerTouch)
                    {
                        Teleport(hit.collider.transform.position);
                    }
                }
                else
                {
                    if (ViveInput.Instance.rightTriggerTouch)
                    {
                        Teleport(hit.collider.transform.position);
                    }
                }

                // TODO
                if (Input.GetMouseButtonDown(0))
                {
                    Teleport(hit.collider.transform.position);
                }

                teleSpot.HighlightOn();
            }

            
        }

        
	}

    void Teleport(Vector3 newPosition)
    {
        Vector3 headToRigCenter = cameraRig.position - head.position;
        headToRigCenter.y = 0f;

        newPosition.y = newPosition.y + heightModifier;
        cameraRig.position = newPosition + headToRigCenter;
    }
}
