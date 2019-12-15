using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixOne
{
    public class SpaceBase : SpaceSettings
    {

        private static SpaceBase instance = null;

        public int[] UpBlock;
        public int[] DownBlock;
        public int[] HorizonBlock;

        // id, center,width
        public Dictionary<int,int[]> UpWindowList;
        public Dictionary<int,int[]> DownWindowList;
        public Dictionary<int,int[]> HorizonWindowList;

        public List<int> HideWindowList;

        public SpaceBase() {
            UpBlock = new int[verticalHeight];
            DownBlock = new int[verticalHeight];
            HorizonBlock = new int[horizonWidth];
            for (int i = 0; i < verticalHeight; i++)
            {
                UpBlock[i] = 0;
                DownBlock[i] = 0;                
            }
            for (int i = 0; i < horizonWidth; i++)
            {
                HorizonBlock[i] = 0;
            }

            UpWindowList = new Dictionary<int, int[]>();
            DownWindowList = new Dictionary<int, int[]>();
            HorizonWindowList = new Dictionary<int, int[]>();
            HideWindowList = new List<int>();
        }
        
        public bool CheckHorizonWindowEmpty(int begin, int end)
        {

            bool isEmpty = true;
            for (int i = begin; i <= end; i++)
            {
                //Debug.Log(i);
                if (HorizonBlock[i] != 0)
                    isEmpty = false;
            }
            return isEmpty;
        }

        public bool CheckUpWindowEmpty(int begin, int end)
        {

            bool isEmpty = true;
            for (int i = begin; i <= end; i++)
            {
                //Debug.Log(i);
                if (UpBlock[i] != 0)
                    isEmpty = false;
            }
            return isEmpty;
        }

        public bool CheckDownWindowEmpty(int begin, int end)
        {

            bool isEmpty = true;
            for (int i = begin; i <= end; i++)
            {
                //Debug.Log(i);
                if (DownBlock[i] != 0)
                    isEmpty = false;
            }
            return isEmpty;
        }

        public Dictionary<int, int> CheckUpMove(int begin, int end)
        {
            Dictionary<int, int> bounds = new Dictionary<int, int>();
            int width = end - begin + 1;
            int center = (begin + end) / 2;

            int moveWidth = 0;
            List<int> moveWindow = new List<int>();

            //check window to be moved
            for (int i = begin; i <= end; i++)
            {
                if (!moveWindow.Contains(UpBlock[i]) && UpBlock[i] != 0)
                {
                    moveWindow.Add(UpBlock[i]);
                    Debug.Log(UpBlock[i]);
                }
            }


            //check left move window
            foreach (int id in moveWindow)
            {
                if (UpWindowList[id][0] + UpWindowList[id][1] / 2 <= end)
                {
                    moveWidth += UpWindowList[id][1];
                }
                else
                {
                    moveWidth += end - (UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2) + 1;
                }
                Debug.Log(id.ToString() + " move width --- " + moveWidth.ToString());

            }
            foreach (int id in moveWindow)
            {
                if (moveWidth < (end - (UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2) + 1))
                {
                    moveWidth = end - (UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2) + 1;
                }
            }
            //check window to be moved
            foreach (int id in UpWindowList.Keys)
            {
                if (UpWindowList[id][0] + UpWindowList[id][1] / 2 >= begin && !HideWindowList.Contains(id))
                {
                    bounds.Add(id, moveWidth);
                    Debug.Log(id.ToString() + " Up move " + moveWidth.ToString());

                }
            }

            return bounds;
        }
        
        public bool isUpHide(int id, int moveWidth)
        {
            bool hide = false;
            if (UpWindowList[id][0] + UpWindowList[id][1] / 2 + moveWidth >= verticalHeight)
                hide = true;
            return hide;
        }

        public Dictionary<int, int> CheckDownMove(int begin, int end)
        {
            Dictionary<int, int> bounds = new Dictionary<int, int>();
            int width = end - begin + 1;
            int center = (begin + end) / 2;

            int moveWidth = 0;
            List<int> moveWindow = new List<int>();
   
            //check window to be moved
            for (int i = begin; i <= end; i++)
            {
                if (!moveWindow.Contains(DownBlock[i]) && DownBlock[i] != 0)
                {
                    moveWindow.Add(DownBlock[i]);
                    Debug.Log(DownBlock[i]);
                }
            }
                       

            //check left move window
            foreach (int id in moveWindow)
            {
                if (DownWindowList[id][0] + DownWindowList[id][1] / 2 <= end)
                {
                    moveWidth += DownWindowList[id][1];
                }
                else
                {
                    moveWidth += end - (DownWindowList[id][0] - (DownWindowList[id][1]-1) / 2) + 1;
                }
                Debug.Log(id.ToString() + " move width --- " + moveWidth.ToString());

            }
            foreach (int id in moveWindow)
            {
                if (moveWidth < (end - (DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2) + 1))
                {
                    moveWidth = end - (DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2) + 1;
                }
            }
            //check window to be moved
            foreach (int id in DownWindowList.Keys)
            {
                if (DownWindowList[id][0] + DownWindowList[id][1] / 2 >= begin && !HideWindowList.Contains(id))
                {
                    bounds.Add(id, moveWidth);
                    Debug.Log(id.ToString() + " down move " + moveWidth.ToString());

                }
            }

            return bounds;
        }

        public bool isDownHide(int id, int moveWidth)
        {
            bool hide = false;
            if (DownWindowList[id][0] + DownWindowList[id][1] / 2 + moveWidth >= verticalHeight)
                hide = true;
            return hide;
        }

        public Dictionary<int, int> CheckHorizonMove(int begin, int end)
        {
            Dictionary<int, int> bounds = new Dictionary<int, int>();
            int width = end - begin + 1;
            int center = (begin + end) / 2;

            Debug.Log("check " + begin.ToString() + " - " + end.ToString());
            
            int leftMoveWidth = 0;
            int rightMoveWidth = 0;


            List<int> moveWindow = new List<int>();
            List<int> leftWindow = new List<int>();
            List<int> rightWindow = new List<int>();
            //check window to be moved
            for (int i = begin; i <= end; i++)
            {
                if (!moveWindow.Contains(HorizonBlock[i]) && HorizonBlock[i] != 0)
                    moveWindow.Add(HorizonBlock[i]);
            }
            //check left move window
            foreach (int id in moveWindow)
            {
                //Debug.Log(id);
                if (HorizonWindowList[id][0] < center)
                {
                    if (HorizonWindowList[id][0] - (HorizonWindowList[id][1]-1) / 2 >= begin)
                    {
                        leftMoveWidth += HorizonWindowList[id][1];
                        leftWindow.Add(id);
                    }
                    else
                    {
                        leftMoveWidth += HorizonWindowList[id][1] / 2 + HorizonWindowList[id][0] - begin + 1;
                        leftWindow.Add(id);
                    }
                }
                else
                {
                    if (HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2 <= end)
                    {
                        rightMoveWidth += HorizonWindowList[id][1];
                        rightWindow.Add(id);
                    }
                    else
                    {
                        rightMoveWidth += (HorizonWindowList[id][1]-1) / 2 + end - HorizonWindowList[id][0] + 1;
                        rightWindow.Add(id);
                    }
                }
            }

            foreach(int id in leftWindow)
            {
                if(leftMoveWidth<(HorizonWindowList[id][0] + HorizonWindowList[id][1]/2 - begin + 1))
                {
                    leftMoveWidth = HorizonWindowList[id][0] + HorizonWindowList[id][1] - begin + 1;
                }
            }

            foreach (int id in rightWindow)
            {
                if (rightMoveWidth < (end - (HorizonWindowList[id][0] - (HorizonWindowList[id][1]-1)/2) + 1))
                {
                    rightMoveWidth = end - (HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2) + 1;
                }
            }
            foreach (int id in HorizonWindowList.Keys)
            {

                if (HorizonWindowList[id][0] < center && !HideWindowList.Contains(id))
                {
                    bounds.Add(id, -leftMoveWidth);
                    Debug.Log(id.ToString() + " left move " + leftMoveWidth.ToString());
                }
                if( HorizonWindowList[id][0] >= center && !HideWindowList.Contains(id))
                {
                    bounds.Add(id, rightMoveWidth);
                    Debug.Log(id.ToString() + " right move " + rightMoveWidth.ToString());

                }
                //Debug.Log("check moving " + id.ToString());

            } 

            return bounds;
        }

        public Dictionary<int, int> CheckHorizonLockMove(int begin, int end)
        {
            Dictionary<int, int> bounds = new Dictionary<int, int>();
            int width = end - begin + 1;
            int center = (begin + end) / 2;

            int leftMoveWidth = 0;
            int rightMoveWidth = 0;

            Debug.Log("check " + begin.ToString() + " - " + end.ToString());

            List<int> moveWindow = new List<int>();

            for (int i = begin; i <= end; i++)
            {
                if (!moveWindow.Contains(HorizonBlock[i]) && HorizonBlock[i] != 0)
                    moveWindow.Add(HorizonBlock[i]);
            }

            if (end < (horizonWidth - verticalWidth) / 2)
            {
                foreach (int id in moveWindow)
                {
                    //move left
                    if (HorizonWindowList[id][0] - (HorizonWindowList[id][1]-1) / 2 >= begin)
                    {
                        leftMoveWidth += HorizonWindowList[id][1];
                    }
                    else
                    {
                        leftMoveWidth += HorizonWindowList[id][1] / 2 + HorizonWindowList[id][0] - begin + 1;
                    }
                }
                foreach (int id in moveWindow)
                {
                    if (leftMoveWidth < (HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2 - begin + 1))
                    {
                        leftMoveWidth = HorizonWindowList[id][0] + HorizonWindowList[id][1] - begin + 1;
                    }
                }


                foreach (int id in HorizonWindowList.Keys)
                {
                    if (HorizonWindowList[id][0] - (HorizonWindowList[id][1]-1) / 2 <= end && !HideWindowList.Contains(id))
                    {
                        bounds.Add(id, -leftMoveWidth);
                        Debug.Log(id.ToString() + " left move " + leftMoveWidth.ToString());
                    }            
                }
                return bounds;
            }
            else if (begin > horizonWidth - (horizonWidth - verticalWidth) / 2 - 1)
            {
                foreach (int id in moveWindow)
                {
                    //move right
                    if (HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2 <= end)
                    {
                        rightMoveWidth += HorizonWindowList[id][1];
                    }
                    else
                    {
                        rightMoveWidth += (HorizonWindowList[id][1]-1) / 2 + end - HorizonWindowList[id][0] + 1;
                    }
                }
                foreach (int id in moveWindow)
                {
                    if (rightMoveWidth < (end - (HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2) + 1))
                    {
                        rightMoveWidth = end - (HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2) + 1;
                    }
                }
                foreach (int id in HorizonWindowList.Keys)
                {
                    if (HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2 >= begin && !HideWindowList.Contains(id))
                    {
                        bounds.Add(id, rightMoveWidth);
                        Debug.Log(id.ToString() + " right move " + rightMoveWidth.ToString());

                    }
                }
                return bounds;
            }            
            //check window to be moved
            bounds = CheckHorizonMove(begin, end);
            return bounds;
            
        }

        public bool isHorizonHide(int id, int moveWidth)
        {
            bool hide = false;
            if (moveWidth > 0)
            {
                if (HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2 + moveWidth >= horizonWidth)
                    hide = true;
            }
            if (moveWidth < 0)
            {
                if (HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2 + moveWidth < 0)
                    hide = true;
            }

            return hide;
        }

        public void SetUpWindowId(int begin, int end, int id)
        {
            for (int i = begin; i <= end; i++)
            {
                UpBlock[i] = id;
            }
            if (!UpWindowList.ContainsKey(id))
                UpWindowList.Add(id, new int[] { (begin + end) / 2, end - begin + 1 });
            else
                UpWindowList[id] = new int[] { (begin + end) / 2, end - begin + 1 };

            Debug.Log("insert up window with id " + id);
        }

        public void SetUpWindowId(Dictionary<int,int> bounds)
        {
            foreach (int id in bounds.Keys)
            {
                UpWindowList[id][0] += bounds[id];
                if(UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2 < 0 || UpWindowList[id][0] + UpWindowList[id][1] / 2 >= verticalHeight)
                {
                    HideWindowList.Add(id);
                    UpWindowList.Remove(id);
                }
                else
                {
                    for (int i = UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2; i <= UpWindowList[id][0] + UpWindowList[id][1] / 2; i++)
                    {
                        UpBlock[i] = id;
                    }
                }
            }
        }

        public void SetDownWindowId(int begin, int end, int id)
        {
            for (int i = begin; i <= end; i++)
            {
                DownBlock[i] = id;
            }
            if (!DownWindowList.ContainsKey(id))
                DownWindowList.Add(id, new int[] { (begin + end) / 2, end - begin + 1 });
            else
                DownWindowList[id] = new int[] { (begin + end) / 2, end - begin + 1 };

            Debug.Log("insert down window with id " + id);
        }

        public void SetDownWindowId(Dictionary<int, int> bounds)
        {
            foreach (int id in bounds.Keys)
            {
                for (int i = DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2; i <= DownWindowList[id][0] + DownWindowList[id][1] / 2; i++)
                {
                    DownBlock[i] = 0;
                }
            }
            foreach (int id in bounds.Keys)
            {                
                DownWindowList[id][0] += bounds[id];
                if (DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2 < 0 || DownWindowList[id][0] + DownWindowList[id][1] / 2 >= verticalHeight)
                {
                    HideWindowList.Add(id);
                    DownWindowList.Remove(id);
                }
                else
                {
                    for (int i = DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2; i <= DownWindowList[id][0] + DownWindowList[id][1] / 2; i++)
                    {
                        DownBlock[i] = id;
                    }
                }
            }
        }

        public void SetHorizonWindowId(int begin, int end, int id)
        {
            for (int i = begin; i <= end; i++)
            {
                HorizonBlock[i] = id;
            }
            if(!HorizonWindowList.ContainsKey(id))
                HorizonWindowList.Add(id, new int[]{ (begin + end) / 2, end - begin + 1 });
            else
                HorizonWindowList[id] = new int[] { (begin + end) / 2, end - begin + 1 };
            //Debug.Log("insert Horizon window with id " + id + " center" + HorizonWindowList[id][0].ToString() + " width" + HorizonWindowList[id][1].ToString());
        }

        public void SetHorizonWindowId(Dictionary<int, int> bounds)
        {
            foreach (int id in bounds.Keys)
            {
                HorizonWindowList[id][0] += bounds[id];
                if (HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2 < 0 || HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2 >= horizonWidth)
                {
                    HideWindowList.Add(id);
                    HorizonWindowList.Remove(id);
                }
                else
                {
                    for (int i = HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2; i <= HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2; i++)
                    {
                        HorizonBlock[i] = id;
                    }
                }
            }
        }

        public void HideUpWindow(int id)
        {
            HideWindowList.Add(id);
            UpWindowList.Remove(id);
        }

        public void HideDownWindow(int id)
        {
            HideWindowList.Add(id);
            DownWindowList.Remove(id);
        }

        public void HideHorizonWindow(int id)
        {
            HideWindowList.Add(id);
            HorizonWindowList.Remove(id);
        }

        public List<int> GetUpWindowIdList(int begin, int end)
        {            
            List<int> IdList = new List<int>();
            for (int i = begin; i <= end; i++)
            {
                if(!IdList.Exists(t => t == UpBlock[i])&& UpBlock[i]!=0)
                    IdList.Add(UpBlock[i]);
            }
            return IdList;
        }

        public List<int> GetDownWindowIdList(int begin, int end)
        {
            List<int> IdList = new List<int>();
            for (int i = begin; i <= end; i++)
            {
                if (!IdList.Exists(t => t == DownBlock[i]) && DownBlock[i] != 0)
                    IdList.Add(DownBlock[i]);
            }
            return IdList;
        }
        
        public List<int> GetHorizonWindowIdList(int begin, int end)
        {
            List<int> IdList = new List<int>();
            for (int i = begin; i <= end; i++)
            {
                if (!IdList.Exists(t => t == HorizonBlock[i]) && HorizonBlock[i] != 0)
                    IdList.Add(HorizonBlock[i]);
            }
            return IdList;
        }

        public void RemoveUpWindow(int id)
        {
            for (int i = UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2; i <= UpWindowList[id][0] + UpWindowList[id][1] / 2; i++)
            {
                UpBlock[i] = 0;
            }
            UpWindowList.Remove(id);
        }
        
        public void RemoveDownWindow(int id)
        {
            for (int i = DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2; i <= DownWindowList[id][0] + DownWindowList[id][1] / 2; i++)
            {
                DownBlock[i] = 0;
            }
            DownWindowList.Remove(id);
        }
        
        public void RemoveHorizonWindow(int id)
        {
            for (int i = HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2; i <= HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2; i++)
            {
                HorizonBlock[i] = 0;
            }
            HorizonWindowList.Remove(id);
        }

        public bool WindowExist(int id)
        {
            return UpWindowList.ContainsKey(id)|| DownWindowList.ContainsKey(id)|| HorizonWindowList.ContainsKey(id);
        }

        public int[] WindowPosition(int id)
        {
            int[] pos = new int[3];
            //up 0 down 1 horizon 2
            if(UpWindowList.ContainsKey(id))
            {
                pos[0] = 0;
                pos[1] = UpWindowList[id][0];
                pos[2] = UpWindowList[id][1];
            }
            else if(DownWindowList.ContainsKey(id))
            {
                pos[0] = 1;
                pos[1] = DownWindowList[id][0];
                pos[2] = DownWindowList[id][1];
            }
            else
            {
                pos[0] = 2;
                pos[1] = HorizonWindowList[id][0];
                pos[2] = HorizonWindowList[id][1];
            }
            
            return pos;
        }
                
        public static SpaceBase SetSpace()
        {
            if (instance = null)
            {
                instance = new SpaceBase();
            }
            return instance;
        }
                
        public void removeWindow(int id)
        {
            if (UpWindowList.ContainsKey(id))
                RemoveUpWindow(id);
            if (DownWindowList.ContainsKey(id))
                RemoveDownWindow(id);
            if (HorizonWindowList.ContainsKey(id))
                RemoveHorizonWindow(id);
        }

        public void removeWindowId(int id)
        {
            if (UpWindowList.ContainsKey(id))
            {
                for (int i = UpWindowList[id][0] - (UpWindowList[id][1] - 1) / 2; i <= UpWindowList[id][0] + UpWindowList[id][1] / 2; i++)
                {
                    UpBlock[i] = 0;
                }
            }
            if (DownWindowList.ContainsKey(id))
            {
                for (int i = DownWindowList[id][0] - (DownWindowList[id][1] - 1) / 2; i <= DownWindowList[id][0] + DownWindowList[id][1] / 2; i++)
                {
                    DownBlock[i] = 0;
                }
            }
            if (HorizonWindowList.ContainsKey(id))
            {
                for (int i = HorizonWindowList[id][0] - (HorizonWindowList[id][1] - 1) / 2; i <= HorizonWindowList[id][0] + HorizonWindowList[id][1] / 2; i++)
                {
                    HorizonBlock[i] = 0;
                }
            }
        }

        public void showWindow(int id)
        {
            HideWindowList.Remove(id);
        }

        public void clearHorizonBlock()
        {
            for(int i = 0; i < horizonWidth; i++)
            {
                HorizonBlock[i] = 0;
            }
        }
    }
}