using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject myObject;
    public ARRaycastManager RaycastManager;

    private void Update()
    {
        //�p�GInput.touchCount>0 �åBTouchPhase = Began
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //�K�[�@��ARRaycastHit�C��ó]�mRaycastManager���u��g
            List<ARRaycastHit> touches = new List<ARRaycastHit>();
            //�N�ھ�Ĳ�N��m�M�����ҤƧڭ̪��C����H
            RaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touches.Count>0)
            {
                GameObject.Instantiate(myObject, touches[0].pose.position, touches[0].pose.rotation);
            }
        }
    }
}
