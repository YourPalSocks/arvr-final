using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandPhysics : MonoBehaviour
{
    public InputActionProperty grabInputSource;
    public float radius = 0.1f;
    public LayerMask grabLayer;
    private bool isGrabbing = false;
    private FixedJoint fixedJoint;
    // Update is called once per frame
    void FixedUpdate()
    {
        bool isGrabButtonPressed = grabInputSource.action.ReadValue<float>() > 0.1f;
        if (isGrabButtonPressed && !isGrabbing)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius, grabLayer, QueryTriggerInteraction.Ignore);
            if(nearbyColliders.Length > 0)
            {
                Rigidbody nearbyRigidBody = nearbyColliders[0].attachedRigidbody;

                fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.autoConfigureConnectedAnchor = false;
                if (nearbyRigidBody)
                {
                    fixedJoint.connectedBody = nearbyRigidBody;
                    fixedJoint.connectedAnchor = nearbyRigidBody.transform.InverseTransformPoint(transform.position);
                }
                isGrabbing = true;
            }
        }
        else if (!isGrabButtonPressed && isGrabbing)
        {
            isGrabbing = false;
            if (fixedJoint)
            {
                Destroy(fixedJoint);
            }
        }
    }
}
