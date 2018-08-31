using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleControl : MonoBehaviour {

    private SteamVR_LaserPointer vrLaserPointer;//射线
    private SteamVR_TrackedController vrTrackedController;//手柄交互

	void Start () {
        vrLaserPointer = transform.GetComponent<SteamVR_LaserPointer>();
        vrTrackedController = transform.GetComponent<SteamVR_TrackedController>();
        Handle needle = new Needle();
        vrLaserPointer.PointerIn += needle.OnHandleIn;//射线进入某个物体时
        vrLaserPointer.PointerOut += needle.OnHandleOut;//射线移除某个物体时
        vrTrackedController.TriggerClicked += needle.OnHandleClick;//按下按键
	}
}
