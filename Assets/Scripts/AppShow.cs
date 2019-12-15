using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;


namespace MixOne
{
    public class AppShow : MonoBehaviour
    {
        //public List<string> Applist = new List<string>(){
        //    "Wechat","Xuetangx","Tonghuashun",
        //    "Baidu","Kuaikan","Lexue","Migu","Huya",
        //    "Iqiyi","Taobao","NeteaseMusic","Tiktok"
        //};

        //private List<string> Hidelist = new List<string>()
        //{
        //    "Lexue","Migu","Huya","Tonghuashun","Iqiyi",
        //    "Baidu_SecondLayer","Baidu_Baike","Baidu_Home","Baidu_News",
        //    "Baidu","Taobao_LiveList","Taobao_Live","Taobao","Tiktok_Video1",
        //    "Tiktok","Kuaikan_Comic2","Kuaikan_Comic2","Kuaikan_Comic3","Kuaikan_Comic4",
        //    "Kuaikan_Comic5","Kuaikan_Comic6","Kuaikan_Comic7","Kuaikan_Comic8","Kuaikan_SecondLayer",
        //    "NeteaseMusic_Music","Wechat_FileTransfer","Wechat_Payment","Wechat_Friend",
        //    "Wechat_Group","Wechat_Underground","Kuaikan","NeteaseMusic","Wechat","Xuetangx"
        //};

        //private Dictionary<string, string> SwitchShowList = new Dictionary<string, string>() {
        //    { "Baidu_Search","Baidu_SecondLayer" },
        //    { "Baidu_ToNews","Baidu_News" },
        //    { "Baidu_ToBaike","Baidu_Baike" },
        //    { "Baidu_ToHome","Baidu_Home" },
        //    { "Taobao_Icon","Taobao_LiveList" },
        //    { "Taobao_LiveList","Taobao_Live" },
        //    { "Tiktok_VideoList","Tiktok_Video1" },
        //    { "Kuaikan_ToComic","Kuaikan_SecondLayer" },
        //    { "Kuaikan_Comic1","Kuaikan_Comic2" },
        //    { "Kuaikan_Comic2","Kuaikan_Comic3" },
        //    { "Kuaikan_Comic3","Kuaikan_Comic4" },
        //    { "Kuaikan_Comic4","Kuaikan_Comic5" },
        //    { "Kuaikan_Comic5","Kuaikan_Comic6" },
        //    { "Kuaikan_Comic6","Kuaikan_Comic7" },
        //    { "Kuaikan_Comic7","Kuaikan_Comic8" },
        //    { "NeteaseMusic_Panel","NeteaseMusic_Music" },
        //    { "Wechat_ToFileTransfer","Wechat_FileTransfer" },
        //    { "Wechat_ToPayment","Wechat_Payment" },
        //    { "Wechat_ToFriend","Wechat_Friend" },
        //    { "Wechat_ToGroup","Wechat_Group" },
        //    { "Wechat_ToUnderground","Wechat_Underground" },          
        //};

        //private Dictionary<string, string> SwitchHideList = new Dictionary<string, string>() {
        //    { "Baidu_ToBaike","Baidu_News" },
        //    { "Baidu_ToHome","Baidu_Baike" },
        //    { "Kuaikan_ToComic","Kuaikan_FirstLayer" },
        //    { "Kuaikan_Comic1","Kuaikan_Comic1" },
        //    { "Kuaikan_Comic2","Kuaikan_Comic2" },
        //    { "Kuaikan_Comic3","Kuaikan_Comic3" },
        //    { "Kuaikan_Comic4","Kuaikan_Comic4" },
        //    { "Kuaikan_Comic5","Kuaikan_Comic5" },
        //    { "Kuaikan_Comic6","Kuaikan_Comic6" },
        //    { "Kuaikan_Comic7","Kuaikan_Comic7" },
        //};

        public void SetAppList()
        {
            string path =
#if UNITY_ANDROID && !UNITY_EDITOR
                    Application.streamingAssetsPath + "/AppList.json";
#elif UNITY_IPHONE && !UNITY_EDITOR
                    Application.streamingAssetsPath + "/AppList.json";
#elif UNITY_STANDLONE_WIN || UNITY_EDITOR
                    Application.streamingAssetsPath + "/AppList.json";
#endif
            Debug.Log(path);

            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);

            string[] Temp = System.IO.Directory.GetFiles("D:/HoloLens/ARView/Assets/Resources/iconList");
            for (int i = 0; i < Temp.Length; i++)
            {
                Temp[i] = Temp[i].Substring(Temp[i].LastIndexOf(@"\") + 1);
                if (Temp[i].EndsWith(".png"))
                {
                    Temp[i] = Temp[i].Replace(".png", "");
                    Debug.Log(Temp[i]);
                    sw.WriteLine(Temp[i]);
                }
            }


            sw.Close();
        }
    }

}
