using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MixOne
{
    public class Connect : MonoBehaviour
    {
        private Button button;
        private InputField IP;

        // Start is called before the first frame update
        void Start()
        {
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(sendInfo);
            IP = GameObject.Find("IP").GetComponent<InputField>();
        }

        public void sendInfo()
        {
            string name = button.name;
            Debug.Log(IP.text);
            if (IP.text == "0.0.0.0" && Application.platform == RuntimePlatform.Android)
                IP.text = "192.168.1.224";
            if (IP.text == "0.0.0.0" && Application.platform == RuntimePlatform.WindowsEditor)
                IP.text = "192.168.1.58";
            SpaceSettings.serverIP = IP.text;
            SceneManager.LoadScene("AR_04");
        }


    }
}