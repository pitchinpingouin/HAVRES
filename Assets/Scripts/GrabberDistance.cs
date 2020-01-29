
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OculusSampleFramework
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrabberDistance : DistanceGrabber
    {

        

       ////float m_objectPullVelocity2 = 10.0f;

        [SerializeField]
        float m_maxGrabDistance2;

        GrabberDistance m_otherHand2;
       // DistanceGrabbable m_target;
        [SerializeField]
        GameObject m_player2;



       [Header("(Optional) Tracking space")]
        [Tooltip("Tracking space of the OVRCameraRig.\nIf tracking space is not set, the scene will be searched.\nThis search is expensive.")]
        public Transform trackingSpace = null;
        [Header("Visual Elements")]
        [Tooltip("Line Renderer used to draw selection ray.")]
        public LineRenderer linePointer = null;
        [Tooltip("Fallback gaze pointer.")]
        public Transform gazePointer = null;
        [Tooltip("Visually, how far out should the ray be drawn.")]
        public float rayDrawDistance = 500;
        [Tooltip("How far away the gaze pointer should be from the camera.")]
        public float gazeDrawDistance = 3;
        [Tooltip("Show gaze pointer as ray pointer.")]
        public bool showRayPointer = true;

        // Start ray draw distance
        private const float StartRayDrawDistance = 0.032f;

        
        private RaycastHit hit;

        public RaycastHit Hit
        {
            get
            {
                return this.hit;
            }

        }

        public void SetPointer(Ray ray)
        {
            float hitRayDrawDistance = rayDrawDistance;
            if (Physics.Raycast(ray, out hit))
            {
                hitRayDrawDistance = hit.distance;
            }

            if (linePointer != null)
            {


                linePointer.SetPosition(0, ray.origin + ray.direction * StartRayDrawDistance);
                linePointer.SetPosition(1, ray.origin + ray.direction * hitRayDrawDistance);
            }

            if (gazePointer != null)
            {
                gazePointer.position = ray.origin + ray.direction * (showRayPointer ? hitRayDrawDistance : gazeDrawDistance);
            }
        }
        public void SetPointerVisibility()
        {
            if (trackingSpace != null && activeController != OVRInput.Controller.None)
            {
                if (linePointer != null)
                {
                    linePointer.enabled = true;
                }
                if (gazePointer != null)
                {
                    gazePointer.gameObject.SetActive(showRayPointer ? true : false);
                }
            }
            else
            {
                if (linePointer != null)
                {
                    linePointer.enabled = false;
                }
                if (gazePointer != null)
                {
                    gazePointer.gameObject.SetActive(showRayPointer ? false : true);
                }
            }
        }



        protected bool FindTargetWithRay(out DistanceGrabbable dgOut, out Collider collOut)
        {
            dgOut = null;
            collOut = null;
            activeController = OVRInputHelpers.GetControllerForButton(OVRInput.Button.PrimaryIndexTrigger, activeController);
            Ray selectionRay = OVRInputHelpers.GetSelectionRay(activeController, trackingSpace);
            SetPointerVisibility();
            SetPointer(selectionRay);
            RaycastHit hit;
            if (Physics.Raycast(selectionRay, out hit, m_maxGrabDistance2, 1 << 10))
            {

                collOut = hit.collider;
                dgOut = hit.collider.gameObject.GetComponent<DistanceGrabbable>();
            }


            return dgOut != null;
        }

        protected override void Start()
        {
            base.Start();
            SphereCollider sc = m_player2.GetComponentInChildren<SphereCollider>();
            m_maxGrabDistance2 = sc.radius + 3.0f;

            GrabberDistance[] grabbers = FindObjectsOfType<GrabberDistance>();
            for (int i = 0; i < grabbers.Length; ++i)
            {
                if (grabbers[i] != this) m_otherHand2 = grabbers[i];
            }
            Debug.Assert(m_otherHand2 != null);
        }

 
        void Update()
        {
            DistanceGrabbable target;
            Collider targetColl;
            FindTargetWithRay(out target, out targetColl);

            if (target != m_target)
            {
                if (m_target != null)
                {
                    m_target.Targeted = m_otherHand2.m_target == m_target;
                }
                if (m_target != null)
                    m_target.ClearColor();
                if (target != null)
                    target.SetColor(m_focusColor);
                m_target = target;
                m_targetCollider = targetColl;
                if (m_target != null)
                {
                    m_target.Targeted = true;
                }
            }
        }
    }
}