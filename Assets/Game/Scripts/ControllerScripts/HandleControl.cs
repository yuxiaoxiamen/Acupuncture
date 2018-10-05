using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleControl : MonoBehaviour {

    private SteamVR_LaserPointer vrLaserPointer;//射线
    private SteamVR_TrackedController vrTrackedController;//手柄交互
    public bool isRadial = true;

	void Start () {
        vrLaserPointer = transform.GetComponent<SteamVR_LaserPointer>();
        Handle handle;
        if (isRadial)
        {
            handle = new Radial();
            vrTrackedController = transform.GetComponent<SteamVR_TrackedController>();
            vrTrackedController.TriggerClicked += handle.OnHandleClick;//按下按键
        }
        else
        {
            handle = new Needle();
        }
        vrLaserPointer.PointerIn += handle.OnHandleIn;//射线进入某个物体时
        vrLaserPointer.PointerOut += handle.OnHandleOut;//射线移除某个物体时
        //vrTrackedController.PadClicked += handle.RotationModel;
	}
}
