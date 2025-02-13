using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit2D hit = Physics2D.Raycast(
                origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),
                direction: Vector2.zero,
                distance: Mathf.Infinity,
                layerMask: grappleLayer
            );


            if(hit.collider != null){
                grapplePoint = hit.point;
                grapplePoint.z = 0;

                joint.connectedAnchor = grapplePoint; //set anchor of grappling hook (for swinging)
                joint.enabled = true;
                joint.distance = grappleLength; //distance of the grapple rope
            }
        }

        if(Input.GetMouseButtonUp(0)){
            joint.enabled = false;
        }
    }
}
