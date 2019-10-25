using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace MixOne
{
    public class LensServer : MonoBehaviour
    {
        // Use this for initialization

        private ControlList cl;
        //public string _ip;
        Socket socketSend;

        private void Start()
        {
            Connnect(SpaceSettings.serverIP);
            cl = GameObject.Find("StatusControl").GetComponent<ControlList>();
            //if(_ip!=null)
            //    _ip = "192.168.3.77";

        }

        public static void SwitchToPC()
        {
            
        }

        //public GameObject controller;

        public void Connnect(string _ip)
        {
            try
            {
                int _port = 6000;
                //Pull up a server service
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(_ip);
                //Create new ip port
                IPEndPoint point = new IPEndPoint(ip, _port);
                Debug.Log(point);
                socketWatch.Bind(point);//bond teh ip
                Debug.Log("Server success!");
                socketWatch.Listen(2);//Listen to 2 devices max
                
                //create thread for listen
                Thread thread = new Thread(Listen);
                thread.IsBackground = true;
                thread.Start(socketWatch);
            }
            catch { }

        }

        
        public void Listen(object o)
        {
            try
            {
                Socket socketWatch = o as Socket;
                while (true)
                {
                    socketSend = socketWatch.Accept();//wait for client connection
                    Debug.Log(socketSend.RemoteEndPoint.ToString() + ":" + "server connection success!");
                    //new thread for recieve message
                    
                    Thread r_thread = new Thread(Received);
                    r_thread.IsBackground = true;
                    r_thread.Start(socketSend);
                }
            }
            catch { }
        }

        void Received(object o)
        {
            try
            {
                Socket socketSend = o as Socket;
                while (true)
                {
                    //recieve message from client
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    //efficent message
                    int len = socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, len);
                    Debug.Log("Server：" + str);
                    //sc.ClientTask(str);
                    cl.pushOperation(str);
                    //Debug.Log("Server2：" + socketSend.RemoteEndPoint + ":" + str);
                    Send(str);
                }
            }
            catch { }
        }

        

        void Send(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            socketSend.Send(buffer);
        }

    }
}