using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public enum ControllerSide { Left, Right };
    public ControllerSide controllerSide;

    private OVRHapticsClip HapticsClip;

    void Start()
    {
        HapticsClip = new OVRHapticsClip(10);
    }

    void Update()
    {
        OVRInput.Controller ovrController;
        if (controllerSide == ControllerSide.Left)
            ovrController = OVRInput.Controller.LTouch;
        else
            ovrController = OVRInput.Controller.RTouch;
        
        bool triggerDown = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, ovrController);
        if (triggerDown)
            ApplyHapticFeedback();
    }

    public void ApplyHapticFeedback()
    {
        HapticsClip.Reset();
        HapticsClip.WriteSample(255);

        if (controllerSide == ControllerSide.Left)
            OVRHaptics.LeftChannel.Preempt(HapticsClip);
        else if (controllerSide == ControllerSide.Right)
            OVRHaptics.RightChannel.Preempt(HapticsClip);
    }
}
