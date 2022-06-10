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
        //如果Input.touchCount>0 並且TouchPhase = Began
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //添加一個ARRaycastHit列表並設置RaycastManager光線投射
            List<ARRaycastHit> touches = new List<ARRaycastHit>();
            //將根據觸摸位置和旋轉實例化我們的遊戲對象
            RaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (touches.Count>0)
            {
                GameObject.Instantiate(myObject, touches[0].pose.position, touches[0].pose.rotation);
            }
        }
    }
}
