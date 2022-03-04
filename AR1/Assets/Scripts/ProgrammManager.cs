using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class ProgrammManager : MonoBehaviour
{
    [Header("Put ur PlaneMarker here")]
    [SerializeField] public GameObject PlaneMarkerPrefab;

    protected Joystick joystick;

    private ARRaycastManager ARRaycastManagerScript;

    private Vector2 TouchPosition;

    public GameObject ObjectToSpawn;

    [Header("Put Joystick here")]
    public GameObject Joystic;

    public GameObject CarToSpawn;

    public bool ChooseObject = false;

    public bool PlacedCar = false;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject SelectedObject;

    [Header("Put Button1 here")]
    public GameObject Button1;
    [Header("Put Button2 here")]
    public GameObject Button2;
    [Header("Put ScrollView here")]
    public GameObject ScrollView;

    [SerializeField] private Camera ARCamera;

    void Start()
    {

        
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
        Joystic.SetActive(false);
        PlaneMarkerPrefab.SetActive(false);
        ScrollView.SetActive(false);

    }

   
    void Update()
    {
        if (ChooseObject)
        {
            ShowMarkerAndSetObject();
            if(!PlacedCar)
            {
                PlacedCar = true;
                Vector3 FirstRoadPosition = new Vector3(ObjectToSpawn.transform.position.x, ObjectToSpawn.transform.position.y, ObjectToSpawn.transform.position.z + 3);
                SpawnPrefab(FirstRoadPosition);
            }
        }
        
        MoveObject();
        
    }

    void ShowMarkerAndSetObject()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //маркер
        if (hits.Count > 0)
        {

            PlaneMarkerPrefab.transform.position = hits[0].pose.position;

            PlaneMarkerPrefab.SetActive(true);

        }
        
        //установка объекта
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
            ChooseObject = false;
            PlaneMarkerPrefab.SetActive(false);
        }

    }

    private void SpawnPrefab(Vector3 spawnposition)
    {
        ObjectToSpawn =  Instantiate(CarToSpawn, spawnposition, Quaternion.identity);
    }

    void MoveObject()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("Unselected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);
                SelectedObject = GameObject.FindWithTag("Selected");
                SelectedObject.transform.position = hits[0].pose.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                if(SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "UnSelected";
                }
            }
        }
    }
    //void Race()
    //{
    //    joystick = FindObjectOfType<Joystick>();
    //    var rigidbody = GetComponent<Rigidbody>();
    //    rigidbody.position = new Vector3(joystick.Horizontal + 1, joystick.Vertical + 1, rigidbody.velocity.z);
    //}
}
