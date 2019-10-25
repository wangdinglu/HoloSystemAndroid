using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace MixOne
{
    public class PhoneClient : MonoBehaviour
    {
        public string _ip;

        // Use this for initialization
        public void StartClient()
        {
            if (_ip != null)
                _ip = "192.168.3.77";
            bt_connect_Click();
        }

        public void SendStop()
        {
            bt_send_Click("Stop");
        }

        public void SendMove()
        {
            bt_send_Click("Move");
        }

        public void SendLeft()
        {
            bt_send_Click("Left");
        }

        public void SendRight()
        {
            bt_send_Click("Right");
        }

        Socket socketSend;
        private void bt_connect_Click()
        {
            try
            {
                int _port = 6000;
                

                //New socket client
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(_ip);
                IPEndPoint point = new IPEndPoint(ip, _port);

                socketSend.Connect(point);
                Debug.Log("Connect success!");
                //New thread for infomation
                Thread c_thread = new Thread(Received);
                c_thread.IsBackground = true;
                c_thread.Start();
            }
            catch (Exception)
            {
                Debug.Log("False IP address...");
            }

        }

        /// <summary>
        /// Recieve from server
        /// </summary>
        void Received()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    int len = socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, len);
                    Debug.Log("Client:" + socketSend.RemoteEndPoint + ":" + str);
                }
                catch { }
            }
        }

        /// <summary>
        /// Send to server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_send_Click(string str)
        {
            try
            {
                string msg = str;
                byte[] buffer = new byte[1024 * 1024 * 3];
                buffer = Encoding.UTF8.GetBytes(msg);
                socketSend.Send(buffer);
            }
            catch { }
        }
    }
}