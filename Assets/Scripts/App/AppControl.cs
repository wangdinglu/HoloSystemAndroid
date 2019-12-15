using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MixOne
{
    public class AppControl : MonoBehaviour
    {
        public Camera testCamera;
        public Camera gyroCamera;
        private GyroCameraControl gcc;
        private GameObject VerticalGrid;
        private GameObject HorizonGrid;
        //active app list
        public static Dictionary<int, string> IdList;
        //active and hide list
        public static List<int> hideAppList;

        public static int IdBase;

        public static Dictionary<int, GameObject> Windows;

        public SpaceBase Space;
        public LayerSystem Layers;
        public static List<GameObject> WindowObject = new List<GameObject>();
        public SpaceCalculation spaceCalculate;
        public WindowSystem windowSystem;
        private GameObject moveGhost;
        private int PickUpId;

        private string[] GridName;

        private void Awake()
        {
            testCamera = GameObject.Find("testCamera").GetComponent<Camera>();
            gyroCamera = GameObject.Find("GyroCamera").GetComponent<Camera>();
            gcc = GameObject.Find("GYROCamera").GetComponent<GyroCameraControl>();

            HorizonGrid = GameObject.Find("HorizontalHide");
            VerticalGrid = GameObject.Find("VerticalHide");


            spaceCalculate = GameObject.Find("StatusControl").GetComponent<SpaceCalculation>();
            Space = GameObject.Find("StatusControl").GetComponent<SpaceBase>();
            Layers = GameObject.Find("StatusControl").GetComponent<LayerSystem>();
            windowSystem = GameObject.Find("StatusControl").GetComponent<WindowSystem>();


            IdList = new Dictionary<int, string>();
            Windows = new Dictionary<int, GameObject>();
            hideAppList = new List<int>();
            IdBase = 120;
            HideGrid();

            moveGhost = GameObject.Find("MoveGhost");
            moveGhost.SetActive(false);
        }

        private void HideGrid()
        {
            HorizonGrid.SetActive(false);
            VerticalGrid.SetActive(false);
        }

        private void ShowGrid()
        {
            HorizonGrid.SetActive(true);
            VerticalGrid.SetActive(true);
        }

        public void hideApp(int id)
        {
            hideAppList.Add(id);
            Windows[id].SetActive(false);
        }

        public void RemoveWindowApp()
        {
            Ray ray;
            RaycastHit hit;

            if (CameraSystem.testMode)
            {
                ray = testCamera.ScreenPointToRay(new Vector3(testCamera.pixelWidth / 2, testCamera.pixelHeight / 2, 0));
            }
            else
            {
                ray = gyroCamera.ScreenPointToRay(new Vector3(gyroCamera.pixelWidth / 2, gyroCamera.pixelHeight / 2, 0));
            }
            if (Physics.Raycast(ray, out hit))
            {
                int AppId = System.Convert.ToInt32(hit.collider.gameObject.name);
                if (Windows.ContainsKey(AppId))
                {
                    Destroy(Windows[AppId]);
                    Windows.Remove(AppId);
                    IdList.Remove(AppId);
                    windowSystem.RemoveWindow(AppId);
                }
            }
        }

        // insert a app accroding to hide position
        public void InsertWindow(string windowName)
        {
            Ray ray;
            RaycastHit hit;
                       
            if (CameraSystem.testMode)
            {
                ray = testCamera.ScreenPointToRay(new Vector3(testCamera.pixelWidth / 2, testCamera.pixelHeight / 2, 0));
            }
            else
            {
                ray = gyroCamera.ScreenPointToRay(new Vector3(gyroCamera.pixelWidth / 2, gyroCamera.pixelHeight / 2, 0));
            }

            ShowGrid();


            if (AppInfo.MultipleApp.Contains(windowName))
            {
                IdList.Add(IdBase, windowName);

                GameObject window = Instantiate(Resources.Load("MultipleApp/" + windowName) as GameObject);
                Windows.Add(IdBase, window);
                window.name = IdBase.ToString();

                if (Physics.Raycast(ray, out hit))
                {
                    GridName = hit.collider.gameObject.name.Split('-');
                    if (GridName.Length == 3)
                    {
                        Debug.Log(hit.collider.gameObject.name);
                        switch (GridName[0])
                        {
                            case "u":
                                windowSystem.InsertUpWindow(windowName, System.Convert.ToInt32(GridName[1]), IdBase);
                                break;
                            case "d":
                                windowSystem.InsertDownWindow(windowName, System.Convert.ToInt32(GridName[1]), IdBase);
                                break;
                            case "h":
                                windowSystem.InsertHorizonWindow(windowName, System.Convert.ToInt32(GridName[1]), IdBase);
                                break;
                        }
                    }
                }
                IdBase += 1;
            }

            if (Physics.Raycast(ray, out hit))
            {

                GridName = hit.collider.gameObject.name.Split('-');
                if (GridName.Length == 3)
                {
                    switch (GridName[0])
                    {
                        case "u":
                            windowName = "v-" + windowName;
                            break;
                        case "d":
                            windowName = "v-" + windowName;                            ;
                            break;
                        case "h":
                            windowName = "h-" + windowName;
                            break;
                    }
                }
            }

            if (AppInfo.SingleApp.Contains(windowName))
            {

                if (!IdList.ContainsKey(AppInfo.WindowInfoList[windowName].Id))
                {
                    
                    GameObject window = Instantiate(Resources.Load("SingleApp/"+windowName) as GameObject);
                    Windows.Add(AppInfo.WindowInfoList[windowName].Id,window);
                    window.name = AppInfo.WindowInfoList[windowName].Id.ToString();
                    IdList.Add(AppInfo.WindowInfoList[windowName].Id, windowName);
                }
                else
                {
                    if (hideAppList.Contains(AppInfo.WindowInfoList[windowName].Id))
                    {
                        Windows[AppInfo.WindowInfoList[windowName].Id].SetActive(true);
                        hideAppList.Remove(AppInfo.WindowInfoList[windowName].Id);
                        windowSystem.ShowWindow(AppInfo.WindowInfoList[windowName].Id);
                    }
                }
                
                if (Physics.Raycast(ray, out hit))
                {

                    GridName = hit.collider.gameObject.name.Split('-');
                    if (GridName.Length == 3)
                    {
                        switch (GridName[0])
                        {
                            case "u":
                                windowSystem.InsertUpWindow(windowName, System.Convert.ToInt32(GridName[1]), AppInfo.WindowInfoList[windowName].Id);
                                break;
                            case "d":
                                windowSystem.InsertDownWindow(windowName, System.Convert.ToInt32(GridName[1]), AppInfo.WindowInfoList[windowName].Id);
                                break;
                            case "h":
                                windowSystem.InsertHorizonWindow(windowName, System.Convert.ToInt32(GridName[1]), AppInfo.WindowInfoList[windowName].Id);
                                break;
                        }
                    }
                }
            }

            HideGrid();
        }

        public void ClearCenter()
        {
            
            GameObject window = Instantiate(Resources.Load("MultipleApp/h7") as GameObject);
            Windows.Add(IdBase, window);
            window.name = IdBase.ToString();
            IdList.Add(IdBase, "h7");
            windowSystem.InsertHorizonWindow("h7", System.Convert.ToInt32(GridName[1]), IdBase);
            Destroy(Windows[IdBase]);
            Windows.Remove(IdBase);
            IdList.Remove(IdBase);
            windowSystem.RemoveWindow(IdBase);

        }

        public void LockMode()
        {
            SystemSetting.isLock = true;
            Debug.Log("lock " + SystemSetting.isLock.ToString());
        }

        public void UnlockMode()
        {
            SystemSetting.isLock = false;
            Debug.Log("unlock " + SystemSetting.isLock.ToString());

        }

        public void RotateHorizonWindows(int number)
        {
            if(SystemSetting.isLock == false)
            {
                windowSystem.RotateHorizonWindows(number);
            }
        }

        public void OpenRecentWindow(int id)
        {
            Ray ray;
            RaycastHit hit;

            if (CameraSystem.testMode)
            {
                ray = testCamera.ScreenPointToRay(new Vector3(testCamera.pixelWidth / 2, testCamera.pixelHeight / 2, 0));
            }
            else
            {
                ray = gyroCamera.ScreenPointToRay(new Vector3(gyroCamera.pixelWidth / 2, gyroCamera.pixelHeight / 2, 0));
            }

            ShowGrid();
            
            if (hideAppList.Contains(id))
            {
                Windows[id].SetActive(true);
                hideAppList.Remove(id);
                windowSystem.ShowWindow(id);
            }
            else
            {
                windowSystem.RemoveWindow(id);
            }

            if (Physics.Raycast(ray, out hit))
            {
                GridName = hit.collider.gameObject.name.Split('-');
                if (GridName.Length == 3)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    switch (GridName[0])
                    {
                        case "u":
                            windowSystem.InsertUpWindow(IdList[id], System.Convert.ToInt32(GridName[1]), id);
                            break;
                        case "d":
                            windowSystem.InsertDownWindow(IdList[id], System.Convert.ToInt32(GridName[1]), id);
                            break;
                        case "h":
                            windowSystem.InsertHorizonWindow(IdList[id], System.Convert.ToInt32(GridName[1]), id);
                            break;
                    }
                }
            }

            HideGrid();
        }

        public void SetDownWindow()
        {
            int id = PickUpId;

            moveGhost.SetActive(false);
            Windows[id].SetActive(true);

            Ray ray;
            RaycastHit hit;

            if (CameraSystem.testMode)
            {
                ray = testCamera.ScreenPointToRay(new Vector3(testCamera.pixelWidth / 2, testCamera.pixelHeight / 2, 0));
            }
            else
            {
                ray = gyroCamera.ScreenPointToRay(new Vector3(gyroCamera.pixelWidth / 2, gyroCamera.pixelHeight / 2, 0));
            }

            ShowGrid();

            if (Physics.Raycast(ray, out hit))
            {
                GridName = hit.collider.gameObject.name.Split('-');
                if (GridName.Length == 3)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    switch (GridName[0])
                    {
                        case "u":
                            windowSystem.InsertUpWindow(IdList[id], System.Convert.ToInt32(GridName[1]), id);
                            break;
                        case "d":
                            windowSystem.InsertDownWindow(IdList[id], System.Convert.ToInt32(GridName[1]), id);
                            break;
                        case "h":
                            windowSystem.InsertHorizonWindow(IdList[id], System.Convert.ToInt32(GridName[1]), id);
                            break;
                    }
                }
            }

            HideGrid();
        }

        public void PickUpWindow()
        {
            Ray ray;
            RaycastHit hit;
            int id;

            if (CameraSystem.testMode)
            {
                ray = testCamera.ScreenPointToRay(new Vector3(testCamera.pixelWidth / 2, testCamera.pixelHeight / 2, 0));
            }
            else
            {
                ray = gyroCamera.ScreenPointToRay(new Vector3(gyroCamera.pixelWidth / 2, gyroCamera.pixelHeight / 2, 0));
            }

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("aaa");
                if (IdList.ContainsKey(System.Convert.ToInt32(hit.collider.gameObject.name)))
                {
                    id = System.Convert.ToInt32(hit.collider.gameObject.name);
                    PickUpId = id;
                    Debug.Log(id);
                    Windows[id].SetActive(false);
                    moveGhost.SetActive(true);
                    Image Ghost = moveGhost.GetComponent<Image>();
                    Ghost.rectTransform.sizeDelta = new Vector2(AppInfo.WindowInfoList[IdList[id]].Width * 700 / 4, AppInfo.WindowInfoList[IdList[id]].Height * 700 / 4);
                    windowSystem.RemoveWindow(id);
                }
            }

           
        }
    }
}

