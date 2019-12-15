using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MixOne
{
    public class AppOpen : MonoBehaviour
    {
        private Button button;
        private ControlList cl;

        void Awake()
        {
            button = this.GetComponent<Button>();
            button.onClick.AddListener(OpenApp);
            cl = GameObject.Find("StatusControl").GetComponent<ControlList>();

        }

        private void OpenApp()
        {
            string name = this.name;
            string[] info = name.Split('-');
            switch (info[0])
            {
                case "App":
                    cl.pushOperation("OpenApp:" + info[1]);
                    //Debug.Log("OpenApp:" + info[1]);
                    
                    break;
                case "System":
                    cl.pushOperation("OpenApp:" + "System" + info[1]);
                    //Debug.Log("OpenApp:" + "System" + info[1]);
                    break;
                case "Quick":
                    quickList(info[1]);
                    break;
            }
            cl.CloseAppList();
        }

        private void quickList(string task)
        {
            switch (task)
            {
                case "Search":
                    cl.pushOperation("OpenApp:" + "Baidu");
                    cl.pushOperation("OpenApp:" + "System" + "Browser");
                    break;
                case "Reading":
                    cl.pushOperation("OpenApp:" + "Qidian");
                    cl.pushOperation("OpenApp:" + "System" + "Reader");
                    break;
                case "Live":
                    cl.pushOperation("OpenApp:" + "Huya");
                    cl.pushOperation("OpenApp:" + "Bilibili");
                    break;
                case "Audio":
                    cl.pushOperation("OpenApp:" + "NeteaseMusic");
                    cl.pushOperation("OpenApp:" + "QQMusic");
                    cl.pushOperation("OpenApp:" + "System" + "Music");
                    break;
                case "Friend":
                    cl.pushOperation("OpenApp:" + "Wechat");
                    cl.pushOperation("OpenApp:" + "Weibo");
                    break;
                case "News":
                    cl.pushOperation("OpenApp:" + "Zhihu");
                    cl.pushOperation("OpenApp:" + "Toutiao");
                    break;
                case "Shopping":
                    cl.pushOperation("OpenApp:" + "JD");
                    cl.pushOperation("OpenApp:" + "Pinduoduo");
                    cl.pushOperation("OpenApp:" + "Taobao");
                    break;
                case "Discovery":
                    cl.pushOperation("OpenApp:" + "Tiktok");
                    cl.pushOperation("OpenApp:" + "Kuaikan");
                    break;
                case "Video":
                    cl.pushOperation("OpenApp:" + "Vqq");
                    cl.pushOperation("OpenApp:" + "Iqiyi");
                    cl.pushOperation("OpenApp:" + "Youku");
                    cl.pushOperation("OpenApp:" + "System" + "Video");
                    break;
                case "Work":
                    cl.pushOperation("OpenApp:" + "Tonghuashun");
                    cl.pushOperation("OpenApp:" + "System" + "Clock");
                    break;
                case "Education":
                    cl.pushOperation("OpenApp:" + "Lexue");
                    cl.pushOperation("OpenApp:" + "Xuetangx");
                    cl.pushOperation("OpenApp:" + "System" + "Clock");
                    break;
            }
        }
    }
}

