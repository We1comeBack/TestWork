using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AimPointScript : MonoBehaviour
{
    public GameObject ObjectToPlace;
    public GameObject ObjectAimPoint;

    [SerializeField] private ARRaycastManager _raycastManager;
    private Pose _objectPose;
    private bool _objectPoseIsValid = false;

    void Start()
    {

    }

    void Update()
    {
        UpdateObjectPose();
        UpdateObjectIndicator();

        if (_objectPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }
    private void PlaceObject()
    {
        Instantiate(ObjectToPlace, _objectPose.position, _objectPose.rotation);
    }

    private void UpdateObjectIndicator()
    {
        if (_objectPoseIsValid)
        {
            ObjectAimPoint.SetActive(true);
            ObjectAimPoint.transform.SetPositionAndRotation(_objectPose.position, _objectPose.rotation);
        }
        else
        {
            ObjectAimPoint.SetActive(false);
        }
    }

    private void UpdateObjectPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        _raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        _objectPoseIsValid = hits.Count > 0;
        if (_objectPoseIsValid)
        {
            _objectPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            _objectPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
