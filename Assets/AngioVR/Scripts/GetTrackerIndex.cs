using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace steamvr.yuansyun
{
    public class GetTrackerIndex : MonoBehaviour
    {

        public SteamVR_TrackedObject TrackedObject;
        public Valve.VR.ETrackedDeviceClass DeviceClass;
        public Valve.VR.ETrackedControllerRole CobntrollerRole;


        // Use this for initialization
        void Start()
        {
            AssignTrackerIndex();
        }

        // Update is called once per frame
        void Update()
        {

        }


        void AssignTrackerIndex()
        {
            for (int i = (int)SteamVR_TrackedObject.EIndex.Device1; i < (int)SteamVR_TrackedObject.EIndex.Device15; i++)
            {
                var device = SteamVR_Controller.Input(i);
                if (device.hasTracking && device.connected && device.valid)
                {
                    var deviceClass = Valve.VR.OpenVR.System.GetTrackedDeviceClass((uint)i);
                    if (deviceClass == DeviceClass)
                    {
                        if (deviceClass == Valve.VR.ETrackedDeviceClass.Controller)
                        {
                            /* the tracked object is the controller */
                            var role = Valve.VR.OpenVR.System.GetControllerRoleForTrackedDeviceIndex((uint)i);
                            if (role == CobntrollerRole)
                            {
                                TrackedObject.SetDeviceIndex(i);
                            }
                        }
                        else
                        {
                            /* the tracked object is a vive tracker */
                            TrackedObject.SetDeviceIndex(i);
                        }

                    }
                }
            }
        }
    }
}
