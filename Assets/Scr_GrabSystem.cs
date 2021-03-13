using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Scr_GrabSystem : MonoBehaviour
{
    // Script for the hand/grabber to grab Scr_Grabbables
    // Currently a hand only application

    public string vState;
    public float vPressValue;
    public float vPressThreshold;

    public Transform vOrigin;
    public Transform vDirection;
    public LayerMask vLayerMask;
    public float vMaxDistance = 5f;
    public float vRadius = 0.05f;

    // Lerp System
    private bool vIsLerping;
    private float vLerp;
    private Vector3 vPositionA;

    //
    public bool vLocked;

    public Transform vAnchorPart;
    public bool vFlipped;
    public float vCurrentAngle;
    public float vAngleMultiplier = 15f;


    public GameObject vTestSphere;

    public Vector3 vPreviousPosition;
    public Vector3 vPreviousAngle;

    public SkinnedMeshRenderer vHandMesh;

    [Header("Grabbed Object")]
    public GameObject vTargetItem;
    public GameObject vGrabbedItem;
    public Scr_Grabbable cScrGrabbable;
    public float vGrippingThreshold = .2f;
    public Scr_Socket_System cSS;


    void Start()
    {
        vPreviousPosition = this.transform.position;
        vPreviousPosition = this.transform.eulerAngles;
    }
    
    void Update()
    {
        Grip();
        //FlipCheck();
        LerpUpdate();
        //LerpUpdate();
        FindConnection();
    }

    public void YBClicked()
    {
        if (vGrabbedItem != null)
        {
            if (vFlipped)
                vFlipped = false;
            else
                vFlipped = true;
        }
    }

    public void Grip()
    {
        vTargetItem = null;
        //Debug.Log("Gripping");

        #region Find a grabbable target
        if (vGrabbedItem == null)
        {
            RaycastHit tHit;
            Ray tRay = new Ray(vOrigin.position, (vDirection.position - vOrigin.position).normalized);
            Debug.DrawRay(vOrigin.position, (vDirection.position - vOrigin.position).normalized);
            if (Physics.SphereCast(tRay, vRadius, out tHit, vMaxDistance, vLayerMask))
            {
                vTestSphere.transform.position = tHit.point;
                //Debug.Log("HIT");
                if (tHit.collider.tag == "Grabbable")
                {
                    vTargetItem = tHit.collider.gameObject;
                }
            }
        }
        #endregion
        
        
        if (vPressValue > vGrippingThreshold)
        {
            #region Start gripping
            
            if (vTargetItem != null)
                if (vGrabbedItem == null)
                {
                    // Get main Scr_Connect_System Part first
                    cScrGrabbable = vTargetItem.GetComponent<Scr_Grabbable>();
                    if (cScrGrabbable != null)
                        if (cScrGrabbable.cSS != null)
                            cScrGrabbable.cSS.enabled = false;
                    // Detach ConnectionSystem if exists
                    if (cScrGrabbable.cCS != null)
                    {
                        // If grabbing gun parts, do gunpart stuff
                        cScrGrabbable.cCS.DetachSelf();                                   // Reset parenting
                        cScrGrabbable.cCS.transform.SetParent(vAnchorPart.transform);     // Set new parent to follow hand
                        vGrabbedItem = cScrGrabbable.cCS.gameObject;                      // Update What items is being grabbed
                        vPositionA = cScrGrabbable.cCS.transform.position;                // Setup Lerping Point
                    }
                    else
                    {
                        // If grabbing NON grabbable gunparts
                        vGrabbedItem = cScrGrabbable.gameObject;
                        vPositionA = cScrGrabbable.transform.position;                // Setup Lerping Point

                    }

                    // Reset Rigidbody for holding the item
                    cScrGrabbable.cRB.isKinematic = true;

                    // Setup Lerping from point A to hand
                    vIsLerping = true;
                    vLerp = 0f;

                    // Turn off Hand render
                    vHandMesh.enabled = false;
                }
                
            #endregion
        }
        else
        {
            #region Let go of grabbed item
            if (vGrabbedItem != null)
            {
                //Transform tTopParent = cPS.transform.root;
                //cPS = vGrabbedItem.GetComponent<Scr_Grabbable>();
                //vGrabbedItem.transform.parent = null;

                // If grabbing gun parts, do gunpart stuff
                if (cScrGrabbable.cCS != null)
                {
                    cScrGrabbable.cCS.DetachSelf();                                   // Reset parenting

                }

                // Reset rigidbody
                cScrGrabbable.cRB.isKinematic = false;
                cScrGrabbable.cRB.useGravity = true;

                // Multiply movement for throwing
                Vector3 tVelocity = (this.transform.position - vPreviousPosition) *2500f * Time.deltaTime;
                cScrGrabbable.cRB.velocity = tVelocity;
                cScrGrabbable.cRB.angularVelocity = tVelocity;


                // if the grabbable has a socket, activate the auto connect
                if (cScrGrabbable.cSS != null)
                {
                    cScrGrabbable.cSS.enabled = true;
                    cScrGrabbable.cSS.TurnOn();
                }

                // Reset Hand to grab again
                vGrabbedItem = null;
                cScrGrabbable = null;
                vHandMesh.enabled = true;
            }
            #endregion
        }

        //Debug.Log("MiddlePressUpdate " + vPressValue.ToString() + " Press / vGrippingTreshhold " + vGrippingThreshold.ToString());
        vPreviousPosition = this.transform.position;
        vPreviousAngle = this.transform.eulerAngles;
    }

    /*
    void FlipCheck()
    {
        if (!vFlipped && vCurrentAngle < 180f)
            vCurrentAngle += vAngleMultiplier * Time.deltaTime;
        if (vFlipped && vCurrentAngle > 0f)
            vCurrentAngle -= vAngleMultiplier * Time.deltaTime;
        vCurrentAngle = Mathf.Clamp(vCurrentAngle, 0f, 180f);
        vAnchor.localEulerAngles = new Vector3(0f, vCurrentAngle, 0f);
    }
    */

    void FixedUpdate()
    {
        //LerpUpdate();
    }


    void LerpUpdate()
    {
        if (vGrabbedItem != null)
        {
            Vector3 tAdjustedAngle = vAnchorPart.transform.eulerAngles + cScrGrabbable.vAngleOffset;
            if (vIsLerping)
            {

                vLerp += 10f * Time.deltaTime;
                if (vLerp > 1f)
                {
                    vIsLerping = false;
                    vLerp = 1f;
                    vGrabbedItem.transform.localPosition = Vector3.zero;
                    vGrabbedItem.transform.localEulerAngles = cScrGrabbable.vAngleOffset;
                    //vGrabbedItem.transform.localEulerAngles = Vector3.zero;
                    //vGrabbedItem.transform.eulerAngles = tAdjustedAngle;

                    vGrabbedItem.transform.position = Vector3.Lerp(vPositionA, vAnchorPart.transform.position, vLerp);
                }
                else
                { 
                    vGrabbedItem.transform.position = Vector3.Lerp(vPositionA, vAnchorPart.transform.position, vLerp);
                    vGrabbedItem.transform.eulerAngles = Vector3.RotateTowards(vGrabbedItem.transform.eulerAngles, tAdjustedAngle, 1f * Time.deltaTime, 0f);
                }
            }


            //vGrabbedItem.transform.localPosition = vAnchor.localPosition;


            /*
            if (vLerp < 1f)
            {
                //vLerp += Time.deltaTime;
                //vGrabbedItem.transform.localPosition = 
            }
            else
            {
                vLocked = true;
                //vGrabbedItem.
                //List<ConstraintSource> tThis = new List<ConstraintSource>();
                //tThis.Add(this.gameObject);
                //vGrabbedItem.transform.parent = this.transform;
                vLerp = 0f;
                //GetComponent<ParentConstraint>().SetSource(0, vMySource);
                Debug.Log("Changing Parent");
            }
            */
        }
    }

    public void FindConnection()
    {
        //Scr_Socket_System
        if (cScrGrabbable != null)
            if (cScrGrabbable.cSS !=null)
                cScrGrabbable.cSS.GrabFind(this.transform.position);


    }

    /*
    public void Gripping(float tPress)
    {
        Debug.Log("Gripping");
        if (vTargetItem != null)
        {
            if (tPress > vGrippingThreshold)
            {
                if (vGrabbedItem == null)
                {
                    vGrabbedItem = vTargetItem;
                }
            } else
            {

                if (vGrabbedItem != null)
                {
                    vGrabbedItem = null;
                }
            }
            //Debug.Log("MiddlePressUpdate " + tPress.ToString() + " Press / vGrippingTreshhold " + vGrippingThreshold.ToString());
        }
    }
    */
}
