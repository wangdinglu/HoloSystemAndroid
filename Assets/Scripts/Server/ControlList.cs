using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

namespace MixOne
{
    public class ControlList : MonoBehaviour
    {
        private static List<string> operation = new List<string>();
        private StatusController sc;
        private GameObject appLayer;
        private GameObject staticLayer;
        private float deltaTime, startTime,deltaAngle,tempAngle;

        private GameObject systemApp;
        private GameObject quickApp;
        private GameObject systemInfo;
        private GameObject storeApp;
        private GameObject activeApp;

        private float vx;
        private float vy;

        public LayerSystem ls;
        public WindowSystem ws;
        public Camera gyroCamera;
        public Camera testCamera;
        private status touchStatus;

        private Vector2 moveDelta;
        private float tapTime = 0.3f;
        private float holdTime = 0.8f;
        private Vector2 startTouch, moveTouch;
        
        private Text info;

        private bool isMoving;
        private GameObject MovingObject;

        private enum status
        {
            Free,
            SingleTap,
            SingleMove,
            SingleHold
        }

        public void pushOperation(string op)
        {
            operation.Add(op);
            //Debug.Log("Add " + op);
        }

        public void remove(string op)
        {
            operation.Remove(op);
        }     


        private void Reset()
        {
            startTouch = moveDelta = moveTouch = Vector2.zero;
            touchStatus = status.Free;
        }

        private void Awake()
        {
            touchStatus = status.Free;
            sc = GameObject.Find("StatusControl").GetComponent<StatusController>();
            //ws = GameObject.Find("WindowManager").GetComponent<WindowSystem>();
            testCamera = GameObject.Find("testCamera").GetComponent<Camera>();
            gyroCamera = GameObject.Find("GyroCamera").GetComponent<Camera>();
            ls = GameObject.Find("StatusControl").GetComponent<LayerSystem>();
            storeApp = GameObject.Find("StoreApp");
            quickApp = GameObject.Find("QuickApp");
            systemApp = GameObject.Find("SystemApp");
            systemInfo = GameObject.Find("SystemInfo");
            activeApp = GameObject.Find("ActiveApp");
        }

        private void Start()
        {
            //ls = GameObject.Find("WindowManager").GetComponent<LayerSystem>();
            appLayer = GameObject.Find("VerticalLayer");
            staticLayer = GameObject.Find("StaticLayer");
            
            tempAngle = Camera.main.transform.eulerAngles.y;
            deltaAngle = Camera.main.transform.eulerAngles.y;

            GameObject layer = ls.GetLayer("Layers");
            layer.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);

            //gyroCamera = GameObject.Find("GyroCamera").GetComponent<Camera>();
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                CameraSystem.SwitchToTestMode();
            }
            else
            {
                testCamera.gameObject.SetActive(false);
            }

            storeApp.SetActive(false);
            quickApp.SetActive(false);
            systemApp.SetActive(false);
            systemInfo.SetActive(false);
            activeApp.SetActive(false);
        }

        public void OpenAppList ()
        {
            storeApp.SetActive(true);
            systemApp.SetActive(true);
            systemInfo.SetActive(true);
        }

        public void OpenRecentList()
        {
            quickApp.SetActive(true);
            systemInfo.SetActive(true);
            activeApp.SetActive(true);
        }

        public void CloseAppList()
        {
            storeApp.SetActive(false);
            quickApp.SetActive(false);
            systemApp.SetActive(false);
            systemInfo.SetActive(false);
            activeApp.SetActive(false);

        }

        private void Update()
        {
            //info.text = (Camera.main.transform.eulerAngles.x.ToString() + "  " + Camera.main.transform.eulerAngles.y.ToString() + "  " + Camera.main.transform.eulerAngles.z.ToString());

            if (operation.Count != 0)
            {
                string op = operation[0];
                sc.ClientTask(op);
                operation.Remove(op);
                //Debug.Log(op);
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                sc.ClientTask("Touch:Close");
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("OpenApp:h3");
                sc.SystemTask("OpenApp:h3");
            }
            if(Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log("OpenApp:h4");
                sc.SystemTask("OpenApp:h4");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("OpenApp:h6");
                sc.SystemTask("OpenApp:h6");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Debug.Log("OpenApp:h6");
                sc.SystemTask("OpenApp:v1");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log("OpenApp:h6");
                sc.SystemTask("OpenApp:v3");
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //Debug.Log("OpenApp:h6");
                sc.SystemTask("OpenApp:v4");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("OpenApp:h6");
                if (systemInfo.activeSelf)
                    OpenAppList();
                else
                    CloseAppList();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("MoveApp");
                sc.SystemTask("MoveApp:122");
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("SetApp");
                sc.SystemTask("SetApp:122");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                //Debug.Log("OpenApp:h6");
                sc.SystemTask("Rotate:3");
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                //Debug.Log("OpenApp:h6");
                sc.SystemTask("Rotate:-3");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                //Debug.Log("OpenApp:h6");
                if(SystemSetting.isLock)
                    sc.SystemTask("Unlock:0");
                else
                    sc.SystemTask("Lock:0");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                sc.SystemTask("RecentApp:123");
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                sc.SystemTask("ClearCenter:0");
            }

            if (CameraSystem.testMode)
            {
                appLayer.transform.eulerAngles = new Vector3(testCamera.transform.eulerAngles.x, testCamera.transform.eulerAngles.y, 0);
                appLayer.transform.localEulerAngles = new Vector3(0, appLayer.transform.localEulerAngles.y, 0);


            }
            else
            {
                appLayer.transform.eulerAngles = new Vector3(gyroCamera.transform.eulerAngles.x, gyroCamera.transform.eulerAngles.y, 0);
                appLayer.transform.localEulerAngles = new Vector3(0, appLayer.transform.localEulerAngles.y, 0);
                
            }
            

        }

    }
}

