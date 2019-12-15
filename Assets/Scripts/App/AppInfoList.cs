using System.Collections;
using System.Collections.Generic;

namespace MixOne
{
    public class AppInfo
    {
        public static List<string> SingleApp = new List<string>()
        {
            "v-Wechat","v-Xuetangx","v-Tonghuashun","v-Zhihu","v-Meituan","v-Kwai","v-Youku","v-JD","v-Pinduoduo",
            "v-Baidu","v-Kuaikan","v-Lexue","v-Huya","v-Toutiao","v-Vqq","v-Qidian","v-Weibo",
            "v-Iqiyi","v-Taobao","v-NeteaseMusic","v-Tiktok","v-QQMusic","v-Bilibili","v-Amap",

            "h-Wechat","h-Xuetangx","h-Tonghuashun","h-Zhihu","h-Meituan","h-Kwai","h-Youku","h-JD","h-Pinduoduo",
            "h-Baidu","h-Kuaikan","h-Lexue","h-Huya","h-Toutiao","h-Vqq","h-Qidian","h-Weibo",
            "h-Iqiyi","h-Taobao","h-NeteaseMusic","h-Tiktok","h-QQMusic","h-Bilibili","h-Amap",

            "v-SystemFile","v-SystemCall","v-SystemNotebook","v-SystemHealth","v-SystemVideo","v-SystemBrowser",
            "v-SystemMusic","v-SystemGallery","v-SystemClock","v-SystemRecord","v-SystemReader",

            "h-SystemFile","h-SystemCall","h-SystemNotebook","h-SystemHealth","h-SystemVideo","h-SystemBrowser",
            "h-SystemMusic","h-SystemGallery","h-SystemClock","h-SystemRecord","h-SystemReader"
        };

        public static List<string> MultipleApp = new List<string>()
        {
            "v1","v2","v3","v4","v5","h1","h2","h3","h4","h5","h6","h7"
        };

        public static Dictionary<string, WindowBase> WindowInfoList = new Dictionary<string, WindowBase>(){
            { "v1",new WindowBase("v1",7,1,1)},
            { "v2",new WindowBase("v2",7,2,2)},
            { "v3",new WindowBase("v3",7,3,3)},
            { "v4",new WindowBase("v4",7,4,4)},
            { "v5",new WindowBase("v5",7,5,5)},
            { "h1",new WindowBase("h1",1,4,11)},
            { "h2",new WindowBase("h2",2,4,12)},
            { "h3",new WindowBase("h3",3,4,13)},
            { "h4",new WindowBase("h4",4,4,14)},
            { "h5",new WindowBase("h5",5,4,15)},
            { "h6",new WindowBase("h6",6,4,16)},
            { "h7",new WindowBase("h7",7,4,17)},

            { "v-Wechat",new WindowBase("v-Wechat",7,3,21)},
            { "v-Xuetangx",new WindowBase("v-Xuetangx",7,3,22)},
            { "v-Tonghuashun",new WindowBase("v-Tonghuashun",7,3,23)},
            { "v-Zhihu",new WindowBase("v-Zhihu",7,3,24)},
            { "v-Meituan",new WindowBase("v-Meituan",7,3,25)},
            { "v-Kwai",new WindowBase("v-Kwai",7,3,26)},
            { "v-Youku",new WindowBase("v-Youku",7,3,27)},
            { "v-JD",new WindowBase("v-JD",7,3,28)},
            { "v-Pinduoduo",new WindowBase("v-Pinduoduo",7,3,29)},
            { "v-Baidu",new WindowBase("v-Baidu",7,3,30)},
            { "v-Kuaikan",new WindowBase("v-Kuaikan",7,3,31)},
            { "v-Lexue",new WindowBase("v-Lexue",7,3,32)},
            { "v-Huya",new WindowBase("v-Huya",7,3,33)},
            { "v-Toutiao",new WindowBase("v-Toutiao",7,3,34)},
            { "v-Vqq",new WindowBase("v-Vqq",7,3,35)},
            { "v-Qidian",new WindowBase("v-Qidian",7,3,36)},
            { "v-Weibo",new WindowBase("v-Weibo",7,3,37)},
            { "v-Iqiyi",new WindowBase("v-Iqiyi",7,3,38)},
            { "v-Taobao",new WindowBase("v-Taobao",7,3,39)},
            { "v-NeteaseMusic",new WindowBase("v-NeteaseMusic",7,3,40)},
            { "v-Tiktok",new WindowBase("v-Tiktok",7,3,41)},
            { "v-QQMusic",new WindowBase("v-QQMusic",7,3,42)},
            { "v-Bilibili",new WindowBase("v-Bilibili",7,3,43)},
            { "v-Amap",new WindowBase("v-Amap",7,3,44)},

            { "v-SystemNotebook",new WindowBase("v-SystemNotebook",7,3,51)},
            { "v-SystemCall",new WindowBase("v-SystemCall",7,3,52)},
            { "v-SystemFile",new WindowBase("v-SystemFile",7,3,53)},
            { "v-SystemHealth",new WindowBase("v-SystemHealth",7,3,54)},
            { "v-SystemVideo",new WindowBase("v-SystemVideo",7,3,55)},
            { "v-SystemBrowser",new WindowBase("v-SystemBrowser",7,3,56)},
            { "v-SystemMusic",new WindowBase("v-SystemMusic",7,3,57)},
            { "v-SystemGallery",new WindowBase("v-SystemGallery",7,3,58)},
            { "v-SystemClock",new WindowBase("v-SystemClock",7,3,59)},
            { "v-SystemRecord",new WindowBase("v-SystemRecord",7,3,60)},
            { "v-SystemReader",new WindowBase("v-SystemReader",7,3,61)},

            { "h-Wechat",new WindowBase("h-Wechat",3,4,71)},
            { "h-Xuetangx",new WindowBase("h-Xuetangx",3,4,72)},
            { "h-Tonghuashun",new WindowBase("h-Tonghuashun",3,4,73)},
            { "h-Zhihu",new WindowBase("h-Zhihu",3,4,74)},
            { "h-Meituan",new WindowBase("h-Meituan",3,4,75)},
            { "h-Kwai",new WindowBase("h-Kwai",3,4,76)},
            { "h-Youku",new WindowBase("h-Youku",3,4,77)},
            { "h-JD",new WindowBase("h-JD",3,4,78)},
            { "h-Pinduoduo",new WindowBase("h-Pinduoduo",3,4,79)},
            { "h-Baidu",new WindowBase("h-Baidu",3,4,80)},
            { "h-Kuaikan",new WindowBase("h-Kuaikan",3,4,81)},
            { "h-Lexue",new WindowBase("h-Lexue",3,4,82)},
            { "h-Huya",new WindowBase("h-Huya",3,4,83)},
            { "h-Toutiao",new WindowBase("h-Toutiao",3,4,84)},
            { "h-Vqq",new WindowBase("h-Vqq",3,4,85)},
            { "h-Qidian",new WindowBase("h-Qidian",3,4,86)},
            { "h-Weibo",new WindowBase("h-Weibo",3,4,87)},
            { "h-Iqiyi",new WindowBase("h-Iqiyi",3,4,88)},
            { "h-Taobao",new WindowBase("h-Taobao",3,4,89)},
            { "h-NeteaseMusic",new WindowBase("h-NeteaseMusic",3,4,90)},
            { "h-Tiktok",new WindowBase("h-Tiktok",3,4,91)},
            { "h-QQMusic",new WindowBase("h-QQMusic",3,4,92)},
            { "h-Bilibili",new WindowBase("h-Bilibili",3,4,93)},
            { "h-Amap",new WindowBase("h-Amap",3,4,94)},

            { "h-SystemNotebook",new WindowBase("h-SystemNotebook",3,4,101)},
            { "h-SystemCall",new WindowBase("h-SystemCall",3,4,102)},
            { "h-SystemFile",new WindowBase("h-SystemFile",3,4,103)},
            { "h-SystemHealth",new WindowBase("h-SystemHealth",3,4,104)},
            { "h-SystemVideo",new WindowBase("h-SystemVideo",3,4,105)},
            { "h-SystemBrowser",new WindowBase("h-SystemBrowser",3,4,106)},
            { "h-SystemMusic",new WindowBase("h-SystemMusic",3,4,107)},
            { "h-SystemGallery",new WindowBase("h-SystemGallery",3,4,108)},
            { "h-SystemClock",new WindowBase("h-SystemClock",3,4,109)},
            { "h-SystemRecord",new WindowBase("h-SystemRecord",3,4,110)},
            { "h-SystemReader",new WindowBase("h-SystemReader",3,4,111)},
        };
                       

        public static List<string> Applist = new List<string>(){
            "Wechat","Xuetangx","Tonghuashun",
            "Baidu","Kuaikan","Lexue","Migu","Huya",
            "Iqiyi","Taobao","NeteaseMusic","Tiktok"
        };

        public static List<string> DynamicApplist = new List<string>(){
            "Wechat","Xuetangx","Tonghuashun",
            "Baidu","Kuaikan","Migu","Huya",
            "Iqiyi","Taobao","NeteaseMusic","Tiktok"
        };

        public static List<string> StaticApplist = new List<string>(){
            "Lexue"
        };

        public static List<string> Hidelist2 = new List<string>()
        {
            "Kuaikan_Comic1","Kuaikan_FirstLayer","Baidu_FirstLayer"
        };

        public static List<string> Hidelist = new List<string>()
        {

            "Baidu_SecondLayer","Baidu_Baike","Baidu_Home","Baidu_News",
            "Taobao_LiveList","Taobao_Live","Tiktok_Video1",
            "Kuaikan_Comic2","Kuaikan_Comic3","Kuaikan_Comic4",
            "Kuaikan_Comic5","Kuaikan_Comic6","Kuaikan_Comic7","Kuaikan_Comic8","Kuaikan_SecondLayer",
            "Wechat_FileTransfer","Wechat_Payment","Wechat_Friend",
            "Wechat_Group","Wechat_Underground","NeteaseMusic_Music1",
            "NeteaseMusic_Music2","NeteaseMusic_Music3","NeteaseMusic_Music4","NeteaseMusic_Music5","NeteaseMusic_Music",
            "Tiktok_Video2","Tiktok_Video3" ,"Tiktok_Video4"

        };

        public static Dictionary<string, string> SwitchShowList = new Dictionary<string, string>() {
            { "Baidu_Search","Baidu_SecondLayer" },
            { "Baidu_ToNews","Baidu_News" },
            { "Baidu_ToBaike","Baidu_Baike" },
            { "Baidu_ToHome","Baidu_Home" },
            { "Taobao_Icon","Taobao_LiveList" },
            { "Taobao_LiveList","Taobao_Live" },
            { "Tiktok_VideoList","Tiktok_Video1" },
            { "Kuaikan_ToComic","Kuaikan_SecondLayer" },
            { "Kuaikan_Comic1","Kuaikan_Comic2" },
            { "Kuaikan_Comic2","Kuaikan_Comic3" },
            { "Kuaikan_Comic3","Kuaikan_Comic4" },
            { "Kuaikan_Comic4","Kuaikan_Comic5" },
            { "Kuaikan_Comic5","Kuaikan_Comic6" },
            { "Kuaikan_Comic6","Kuaikan_Comic7" },
            { "Kuaikan_Comic7","Kuaikan_Comic8" },
            { "NeteaseMusic_Panel","NeteaseMusic_Music" },
            { "Wechat_ToFileTransfer","Wechat_FileTransfer" },
            { "Wechat_ToPayment","Wechat_Payment" },
            { "Wechat_ToFriend","Wechat_Friend" },
            { "Wechat_ToGroup","Wechat_Group" },
            { "NeteaseMusic_Song1","NeteaseMusic_Music1" },
            { "NeteaseMusic_Song2","NeteaseMusic_Music2" },
            { "NeteaseMusic_Song3","NeteaseMusic_Music3" },
            { "NeteaseMusic_Song4","NeteaseMusic_Music4" },
            { "NeteaseMusic_Song5","NeteaseMusic_Music5" },
            { "Tiktok_Live","Tiktok_Video2" },
            { "Tiktok_Video2","Tiktok_Video3" },
            { "Tiktok_Video3","Tiktok_Video4" },

        };


        public static Dictionary<string, string> SwitchHideList = new Dictionary<string, string>() {
            { "Baidu_ToBaike","Baidu_Home" },
            //{ "Baidu_ToHome","Baidu_News" },
            { "Baidu_ToNews","Baidu_Baike" },
            { "Kuaikan_ToComic","Kuaikan_FirstLayer" },
            { "Kuaikan_Comic1","Kuaikan_Comic1" },
            { "Kuaikan_Comic2","Kuaikan_Comic2" },
            { "Kuaikan_Comic3","Kuaikan_Comic3" },
            { "Kuaikan_Comic4","Kuaikan_Comic4" },
            { "Kuaikan_Comic5","Kuaikan_Comic5" },
            { "Kuaikan_Comic6","Kuaikan_Comic6" },
            { "Kuaikan_Comic7","Kuaikan_Comic7" },
            { "Baidu_Search","Baidu_FirstLayer" },

        };
    }
}

