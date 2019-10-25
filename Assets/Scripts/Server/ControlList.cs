using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MixOne
{
    public class ControlList : MonoBehaviour
    {
        private static List<string> operation = new List<string>();
        private StatusController sc;
        private GameObject appLayer;
        private GameObject staticLayer;
        private float deltaTime, startTime;

        public LayerSystem ls;
        public WindowSystem ws;
        public Camera gyroCamera;
        public Camera testCamera;
        private status touchStatus;

        private Vector2 moveDelta;
        private float tapTime = 0.3f;
        private float holdTime = 0.8f;
        private Vector2 startTouch, moveTouch;

        public GameObject pointer;

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
            ws = GameObject.Find("WindowManager").GetComponent<WindowSystem>();
            testCamera = GameObject.Find("testCamera").GetComponent<Camera>();
            gyroCamera = GameObject.Find("GyroCamera").GetComponent<Camera>();
        }

        private void Start()
        {
            ls = GameObject.Find("WindowManager").GetComponent<LayerSystem>();
            appLayer = ls.GetLayer("ApplicationLayer");
            staticLayer = ls.GetLayer("StaticLayer");

            //gyroCamera = GameObject.Find("GyroCamera").GetComponent<Camera>();
        }

        private void Update()
        {
            if (operation.Count != 0)
            {
                string op = operation[0];
                sc.ClientTask(op);
                operation.Remove(op);

            }
            if (Input.GetMouseButton(0))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startTouch = Input.mousePosition;
                    deltaTime = 0;
                    startTime = Time.time;
                    moveTouch = Input.mousePosition;

                }
                else
                {
                    deltaTime = Time.time - startTime;
                    moveDelta = (Vector2)Input.mousePosition - startTouch;

                    if (moveDelta.magnitude < 20 && deltaTime > holdTime)
                    {
                        if (touchStatus != status.SingleHold && touchStatus != status.SingleMove)
                        {
                            sc.ClientTask("Touch:Hold");
                            Debug.Log("Hold");
                            touchStatus = status.SingleHold;
                        }

                    }
                    else if (deltaTime > tapTime && moveDelta.magnitude > 20)
                    {
                        pointer.transform.position = Input.mousePosition;

                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                deltaTime = Time.time - startTime;
                moveDelta = (Vector2)Input.mousePosition - startTouch;
                //t.text ="Touch end in " + deltaTime.ToString());
                if (deltaTime < tapTime)
                {
                    if (moveDelta.magnitude < 20)
                    {
                        sc.ClientTask("Touch:Tap");
                        Debug.Log("Tap");
                        touchStatus = status.SingleTap;

                    }
                    else if (moveDelta.magnitude > 50)
                    {
                        float x = moveDelta.x;
                        float y = moveDelta.y;
                        if (Mathf.Abs(x) > Mathf.Abs(y))
                        {
                            if (x < 0)
                            {
                                sc.ClientTask("Touch:Left");
                                Debug.Log("Left");
                            }
                            else
                            {
                                sc.ClientTask("Touch:Right");
                                Debug.Log("Right");
                            }
                        }
                        else
                        {
                            if (y < 0)
                            {
                                sc.ClientTask("Touch:Down");
                                Debug.Log("Down");
                            }
                            else
                            {
                                sc.ClientTask("Touch:Up");
                                Debug.Log("Up");
                            }
                        }
                    }
                }
                Reset();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                sc.ClientTask("Touch:Close");
            }

            if (CameraSystem.testMode)
            {
                if (testCamera.transform.eulerAngles.x < 25)
                {
                    appLayer.transform.eulerAngles = new Vector3(0, testCamera.transform.eulerAngles.y, 0);
                }
                staticLayer.transform.eulerAngles = testCamera.transform.eulerAngles;

            }
            else
            {
                if (gyroCamera.transform.eulerAngles.x < 25)
                {
                    appLayer.transform.eulerAngles = new Vector3(0, gyroCamera.transform.eulerAngles.y, 0);
                }               
                staticLayer.transform.eulerAngles = gyroCamera.transform.eulerAngles;

            }


        }

        
    }
}

