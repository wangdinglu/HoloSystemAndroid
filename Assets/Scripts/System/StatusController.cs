using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.Video;


namespace MixOne
{
    public class StatusController : MonoBehaviour
    {
        
        public LayerSystem ls;
        public WindowSystem ws;
        public LensServer server;
        public CameraSystem cs;
        public GazeCenter gc;
        public AppControl ap;
        private bool cameraHold = false;
        private GameObject layer;
        private ControlList cl;
        private string tapName;
        private string parentName;

        private List<string> LayerTaskList = new List<string>
        {
            "Stop","Move","Left","Right"
        };

        private List<string> WindowTaskList = new List<string>
        {
            "NeteaseMusic","Tiktok","Wechat","Subscription","Blog"
        };

        //private Dictionary<string>

        public void Awake()
        {
            //cs = GameObject.Find("WindowManager").GetComponent<CameraSystem>();
            ls = GameObject.Find("StatusControl").GetComponent<LayerSystem>();
            cl = GameObject.Find("StatusControl").GetComponent<ControlList>();
            //ws = GameObject.Find("WindowManager").GetComponent<WindowSystem>();
            //server = GameObject.Find("ServerManager").GetComponent<LensServer>();
            gc = GameObject.Find("PointerImage").GetComponent<GazeCenter>();
            ap = GameObject.Find("StatusControl").GetComponent<AppControl>();
            
        }


        public void CameraTask(string task)
        {

            if (cameraHold)
            {
                cs.EnableGyro();
                cameraHold = !cameraHold;
                System.Threading.Thread.Sleep(100);
                layer = ls.GetLayer("DynamicLayer");
                layer.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);
                layer = ls.GetLayer("ApplicationLayer");
                layer.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0);
                
            }
            else
            {
                cs.StopGyro();
                cameraHold = !cameraHold;
            }
            
        }

        public void LayerTask(string task)
        {
            
            //Debug.Log("-----");
            switch (task)
            {
                
                case "Left":
                    layer = ls.GetLayer("DynamicLayer");
                    //GameObject windows = layer.transform.ge
                    layer.transform.Rotate(new Vector3(0, -10f, 0));
                    ls.RotateDynamicWindows(layer, -10);
                    //server.Send(layer.transform.eulerAngles.ToString());
                    break;
                case "Right":
                    layer = ls.GetLayer("DynamicLayer");
                    ls.RotateDynamicWindows(layer, +10);
                    layer.transform.Rotate(new Vector3(0, +10f, 0));
                    //server.Send(obj.transform.eulerAngles.ToString());
                    break;
                case "Up":

                    layer = ls.GetLayer("Layers");
                    layer.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x,Camera.main.transform.eulerAngles.y,0);
                    
                    //server.Send(obj.transform.eulerAngles.ToString());

                    break;
                case "Down":

                    //layer = ls.GetLayer("DynamicLayer");
                    //ws.RotateDynamicCamera(+10);
                    //layer.transform.Rotate(new Vector3(0, +10f, 0));
                    //server.Send(obj.transform.eulerAngles.ToString());
                    break;
                default:
                    break;

            }
        }

        public void TouchTask(string task)
        {
            switch (task)
            {
                case "Tap":

                    GameObject collider = gc.GetObject();
                    if (collider != null)
                    {
                        tapName = collider.name;
                        parentName = collider.transform.parent.name;

                        if (collider.tag == "Grid")
                        {
                            Debug.Log(tapName);
                            Debug.Log(parentName);
                        }
                        //if (WindowSystem.Applist.Contains(tapName) & WindowSystem.DynamicApplist.Contains(tapName))
                        //{
                        //    GameObject layer = ls.GetLayer("DynamicLayer");
                        //    if (ws.CheckExist(tapName))
                        //    {
                        //        ws.PutDynamicWindowForward(layer, tapName);
                        //    }
                        //    else
                        //    {
                        //        ws.insertDynamicWindow(layer, tapName);
                        //    }
                        //}
                        //if (WindowSystem.Applist.Contains(tapName) & WindowSystem.StaticApplist.Contains(tapName))
                        //{
                        //    GameObject layer = ls.GetLayer("StaticLayer");
                        //    if (ws.CheckExist(tapName))
                        //    {
                        //        ws.PutStaticWindowForward(layer, tapName);
                        //    }
                        //    else
                        //    {
                        //        ws.insertStaticWindow(layer, tapName);
                        //    }
                        //}
                        //if (WindowSystem.SwitchShowList.ContainsKey(tapName))
                        //{
                        //    ws.SwitchStatus(WindowSystem.SwitchShowList[tapName]);
                        //}
                        //if (WindowSystem.SwitchHideList.ContainsKey(tapName))
                        //{
                        //    ws.SwitchStatus(WindowSystem.SwitchHideList[tapName]);
                        //}
                    }
                    break;
                case "Hold":
                    GameObject colliderClose = gc.GetObject();
                    if (colliderClose != null)
                    {
                        string closeName = colliderClose.name;
                        //if (ws.CheckExist(closeName))
                        //{
                        //    Debug.Log("Closing " + closeName);
                        //    ws.CloseWindow(closeName);
                        //}
                    }
                    break;

                default:
                    break;
            }
            
        }

        public void SystemTask(string task)
        {
            string[] taskInfo = task.Split(':');
            switch (taskInfo[0])
            {
                case "OpenApp":
                    ap.InsertWindow(taskInfo[1]);
                    break;
                case "CloseApp":
                    ap.RemoveWindowApp();
                    break;
                case "MoveApp":
                    ap.PickUpWindow();
                    break;
                case "SetApp":
                    ap.SetDownWindow();
                    break;
                case "Rotate":
                    ap.RotateHorizonWindows(System.Convert.ToInt32(taskInfo[1]));
                    break;
                case "Lock":
                    ap.LockMode();
                    break;
                case "Unlock":
                    ap.UnlockMode();
                    break;
                case "RecentApp":
                    ap.OpenRecentWindow(System.Convert.ToInt32(taskInfo[1]));
                    break;
                case "ClearCenter":
                    ap.ClearCenter();
                    break;

            }
        }

        public void ClientTask(string task)
        {
            string[] taskInfo = task.Split(':');
            //Debug.Log(window.gameObject.name);
            switch (taskInfo[0])
            {
                case "OpenApp":
                    ap.InsertWindow(taskInfo[1]);
                    break;
                case "CloseApp":
                    ap.RemoveWindowApp();
                    break;
                case "MoveApp":
                    ap.PickUpWindow();
                    break;
                case "SetApp":
                    ap.SetDownWindow();
                    break;
                case "Rotate":
                    ap.RotateHorizonWindows(System.Convert.ToInt32(taskInfo[1]));
                    break;
                case "Lock":
                    ap.LockMode();
                    break;
                case "Unlock":
                    ap.UnlockMode();
                    break;
                case "RecentApp":
                    ap.OpenRecentWindow(System.Convert.ToInt32(taskInfo[1]));
                    break;
                case "ClearCenter":
                    ap.ClearCenter();
                    break;

            }
            switch (taskInfo[1])
            {
                case "OpenApp":
                    ap.InsertWindow(taskInfo[1]);
                    break;
                case "DualHold":
                    CameraTask(taskInfo[1]);
                    //server.Send(obj.transform.eulerAngles.ToString());
                    break;
                case "Left":
                    LayerTask(taskInfo[1]);
                    break;
                case "Right":
                    LayerTask(taskInfo[1]);
                    break;
                case "Up":
                    LayerTask(taskInfo[1]);
                    break;
                case "Down":
                    LayerTask(taskInfo[1]);
                    break;
                //server.Send(obj.transform.eulerAngles.ToString());
                case "Tap":
                    TouchTask(taskInfo[1]);
                    break;
                case "Hold":
                    TouchTask(taskInfo[1]);
                    break;
                default:
                    break;

            }

            if (taskInfo[1].Contains("x/"))
            {
                Debug.Log(taskInfo[1]);
                string[] move = taskInfo[1].Replace("Touch","").Split('/');
                gc.MovePointer(new Vector3(float.Parse(move[1]), float.Parse(move[3]),0));
            }

        }

        public void testCam()
        {
            LayerTask("Up");
        }

        public void CloseApp()
        {
            ap.RemoveWindowApp();
        }

        public void OpenApplist()
        {
            cl.OpenAppList();
        }
    }

}
