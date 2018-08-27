using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleControl : MonoBehaviour {

    private SteamVR_LaserPointer vrLaserPointer;
    private SteamVR_TrackedController vrTrackedController;

	// Use this for initialization
	void Start () {
        vrLaserPointer = transform.GetComponent<SteamVR_LaserPointer>();
        vrTrackedController = transform.GetComponent<SteamVR_TrackedController>();
        Handle needle = new Needle();
        vrLaserPointer.PointerIn += needle.OnHandleIn;
        vrLaserPointer.PointerOut += needle.OnHandleOut;
        vrTrackedController.TriggerClicked += needle.OnHandleClick;
	}
}
