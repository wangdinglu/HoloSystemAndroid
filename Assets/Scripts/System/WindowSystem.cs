using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixOne
{
    public class WindowSystem : MonoBehaviour
    {
        public SpaceBase Space;
        public LayerSystem Layers;
        public static List<GameObject> WindowObject = new List<GameObject>();

        public SpaceCalculation SpaceCalculate;
        public GameObject window;
        private AppControl appControl;

        private bool aiming;
        private float lerpValue = 0;
        private float movementTime = 5;
        
        void Awake()
        {
            SpaceCalculate = GameObject.Find("StatusControl").GetComponent<SpaceCalculation>();
            Space = GameObject.Find("StatusControl").GetComponent<SpaceBase>();
            Layers = GameObject.Find("StatusControl").GetComponent<LayerSystem>();
            appControl = GameObject.Find("StatusControl").GetComponent<AppControl>();
        }

        

        public string GetWindowName(int id)
        {
            return AppControl.IdList[id];
        }

        public WindowBase GetWindowInfo(string windowName)
        {
            return AppInfo.WindowInfoList[windowName];
        }

        public GameObject GetWindowObject(int id)
        {
            //Debug.Log("try to get window: " + id.ToString());

            window = AppControl.Windows[id];
            return window;
        }

        public List<GameObject> GetObjectList(int[] moveId)
        {
            List<int> IdList = new List<int>();
            int item = 0;
            for (int i = 0; i < moveId.Length; i++)
            {
                item = moveId[i];
                if (!IdList.Exists(t => t == item) && (item != 0))
                {
                    IdList.Add(item);
                }
            }
            List<GameObject> ObjectList = new List<GameObject>();
            foreach (int id in IdList)
            {
                ObjectList.Add(GetWindowObject(id));
                //Debug.Log("Get object move --------- " + ws.GetWindowName(id));
            }
            return ObjectList;
        }

        public void InsertUpWindow(string windowName, int position, int windowId)
        {
            GameObject window = GetWindowObject(windowId);
            WindowBase windowInfo = GetWindowInfo(windowName);
            
            int[] bounds = SpaceCalculate.GetUpBounds(position, windowInfo.Height);
            bool isEmpty = Space.CheckUpWindowEmpty(bounds[0], bounds[1]);

            if (!isEmpty)
            {
                Dictionary<int, int> moveBounds = Space.CheckUpMove(bounds[0], bounds[1]);
                foreach(int id in moveBounds.Keys)
                {
                    if (!Space.isUpHide(id,moveBounds[id]))
                    {
                        GetWindowObject(id).transform.localEulerAngles += new Vector3(-2 * moveBounds[id], 0, 0);
                    }
                    else
                    {
                        GetWindowObject(id).transform.localEulerAngles += new Vector3(-2 * moveBounds[id], 0, 0);
                        appControl.hideApp(id);
                    }
                    Space.removeWindowId(id);
                }
                Space.SetUpWindowId(moveBounds);
            }
            
            Space.SetUpWindowId(bounds[0], bounds[1], windowId);
            window.transform.parent = Layers.GetLayer("VerticalLayer").transform;
            window.transform.localEulerAngles = new Vector3(-(bounds[0] + bounds[1]) - 1 - SpaceBase.horizonHeight, 0, 0);
        }

        public void InsertDownWindow(string windowName, int position, int windowId)
        {
            GameObject window = GetWindowObject(windowId);
            WindowBase windowInfo = GetWindowInfo(windowName);

            Debug.Log(position);
            int[] bounds = SpaceCalculate.GetDownBounds(position, windowInfo.Height);
            bool isEmpty = Space.CheckDownWindowEmpty(bounds[0], bounds[1]);
            Debug.Log(bounds[0].ToString() + "-" + bounds[1].ToString());

            if (!isEmpty)
            {
                Dictionary<int, int> moveBounds = Space.CheckDownMove(bounds[0], bounds[1]);
                foreach (int id in moveBounds.Keys)
                {
                    if (!Space.isDownHide(id, moveBounds[id]))
                    {
                        GetWindowObject(id).transform.localEulerAngles += new Vector3(2 * moveBounds[id], 0, 0);
                    }
                    else
                    {
                        GetWindowObject(id).transform.localEulerAngles += new Vector3(2 * moveBounds[id], 0, 0);
                        appControl.hideApp(id);
                    }
                    Space.removeWindowId(id);

                }
                Space.SetDownWindowId(moveBounds);
            }

            Space.SetDownWindowId(bounds[0], bounds[1], windowId);
            window.transform.parent = Layers.GetLayer("VerticalLayer").transform;
            window.transform.localEulerAngles = new Vector3((bounds[0] + bounds[1]) + 1 + SpaceBase.horizonHeight, 0, 0);
        }

        public void InsertHorizonWindow(string windowName, int position, int windowId)
        {
            GameObject window = GetWindowObject(windowId);
            WindowBase windowInfo = GetWindowInfo(windowName);

            int[] bounds = new int[2];
           
            if (SystemSetting.isLock)
            {
                bounds = SpaceCalculate.GetHorizonLockBounds(position, windowInfo.Width);
                Debug.Log("Insert in lock mode!");

                if (!Space.CheckHorizonWindowEmpty(bounds[0], bounds[1]))
                {
                    Dictionary<int, int> moveBounds = Space.CheckHorizonLockMove(bounds[0], bounds[1]);
                    foreach (int id in moveBounds.Keys)
                    {
                        if (!Space.isHorizonHide(id, moveBounds[id]))
                        {
                            GetWindowObject(id).transform.localEulerAngles += new Vector3(0, 2 * moveBounds[id], 0);
                        }
                        else
                        {
                            GetWindowObject(id).transform.localEulerAngles += new Vector3(0, 2 * moveBounds[id], 0);
                            appControl.hideApp(id);
                        }
                        Space.removeWindowId(id);

                    }
                    Space.SetHorizonWindowId(moveBounds);
                }
            }
            else
            {
                bounds = SpaceCalculate.GetHorizonFreeBounds(position, windowInfo.Width);
                
                if (!Space.CheckHorizonWindowEmpty(bounds[0], bounds[1]))
                {
                    //Debug.Log("not empty");
                    Dictionary<int, int> moveBounds = Space.CheckHorizonMove(bounds[0], bounds[1]);
                    foreach (int id in moveBounds.Keys)
                    {
                        if (!Space.isHorizonHide(id, moveBounds[id]))
                        {
                            GetWindowObject(id).transform.localEulerAngles += new Vector3(0, 2 * moveBounds[id], 0);
                        }
                        else
                        {
                            GetWindowObject(id).transform.localEulerAngles += new Vector3(0, 2 * moveBounds[id], 0);
                            appControl.hideApp(id);
                        }
                        Space.removeWindowId(id);

                    }
                    Space.SetHorizonWindowId(moveBounds);
                }
            }


            Space.SetHorizonWindowId(bounds[0], bounds[1], windowId);
            window.transform.parent = Layers.GetLayer("HorizonLayer").transform;
            window.transform.localEulerAngles = new Vector3(0, (bounds[0] + bounds[1]) + 1 - SpaceBase.horizonWidth, 0);
        }


        public void RotateHorizonWindows(int block)
        {
            float time = 0.5f;
            aiming = true;
            List<int> horizonWindows = Space.GetHorizonWindowIdList(0,SpaceSettings.horizonWidth-1);
            List<GameObject> windowObjects = new List<GameObject>();
            Dictionary<int, int> bounds = new Dictionary<int, int>();
            foreach(int id in horizonWindows)
            {
                if (!Space.isHorizonHide(id, block))
                {
                    windowObjects.Add(GetWindowObject(id));
                }
                else
                {
                    GetWindowObject(id).SetActive(false);
                }
                bounds.Add(id, block);
            }
            Space.clearHorizonBlock();
            Space.SetHorizonWindowId(bounds);
            float angle = block * 2;
            //foreach (GameObject window in windowObjects)
            //{
            //    window.transform.localEulerAngles += new Vector3(0, angle, 0);
            //}
            StartCoroutine(RotateHorizonWindow(windowObjects, 0.04f*(float)block, 0.5f));
            //StopCoroutine(RotateHorizonWindow(windowObjects, (float)block / time * Time.deltaTime, time));

        }
        
        IEnumerator RotateHorizonWindow(List<GameObject> windows, float angle, float time)
        {
            //Debug.Log(angle);
            //Debug.Log(time);
            for (float timer = time; timer > 0; timer -= 0.02f)
            {
                foreach(GameObject window in windows)
                {
                    window.transform.localEulerAngles += new Vector3(0,angle / time, 0);
                }
                yield return 0;
            }
            
        }
        
        public void RemoveWindow(int id)
        {
            Space.removeWindow(id);
        }

        public void RemoveWindowId(int id)
        {
            Space.removeWindowId(id);
        }

        public void ShowWindow(int id)
        {
            Space.showWindow(id);
        }
    }

}

