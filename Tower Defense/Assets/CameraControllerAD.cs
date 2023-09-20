using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerAD : MonoBehaviour
{
    Vector3 touchStart;
    [Range(0.1f, 1f)]
    public float panSpeed = 0.1f;

    [Range(0.1f, 1f)]
    public float zoomSpeed = 0.1f;

    public float minZoom = 1f;
    public float maxZoom = 100f;

    private float currHeight;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam= GetComponent<Camera>();
        currHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //pannin0
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPos = Input.GetTouch(0).deltaPosition;
            Debug.Log(touchDeltaPos);
            //Vector3 pan = cam.ScreenToWorldPoint(new Vector3(-touchDeltaPos.x, 0, -touchDeltaPos.y));
            //transform.Translate(pan * panSpeed);
            transform.Translate(-touchDeltaPos.x * panSpeed, -touchDeltaPos.y * panSpeed, 0);
            
            //transform.position = new Vector3(
            //    Mathf.Clamp(transform.position.x, -9.50f, 40f),
            //    Mathf.Clamp(transform.position.y, 9.3f, 16f),
            //    Mathf.Clamp(transform.position.z, 22f, 55f));

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, 6f, 30f),
                currHeight,
            Mathf.Clamp(transform.position.z, -15f, 70f));
            //        transform.position = new Vector3(
            //transform.position.x,
            //currHeight,
            //transform.position.z);
        }
        //zooming
        else if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = t0.position - t0.deltaPosition;
            Vector2 touch1PrevPos = t1.position - t1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (t0.position - t1.position).magnitude;

            float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

            cam.fieldOfView += deltaMagDiff * zoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minZoom, maxZoom);
        }

    }

}
