using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;
using System;

public class SendPos : MonoBehaviour
{
    public string server_address = "tcp://*:5556";
    private volatile bool threadRunning = true;
    private Thread thread;
    private PublisherSocket socket;
    private Vector3 position;
    private bool newPosition = false;

    void Awake()
    {
        RayPosTracker.NotifyPos += SendNewPos; 
        thread = new Thread(new ThreadStart(ClientOnThreadPUB)); 
        thread.Start();
    }

    void ClientOnThreadPUB()
    {
        AsyncIO.ForceDotNet.Force();
        using (socket = new PublisherSocket())
        {
            socket.Options.SendHighWatermark = 1000;
            socket.Bind(server_address);
            
            while (threadRunning)
            {
                if(newPosition)
                {
                socket.SendMoreFrame("POS").SendFrame(position.ToString());
                newPosition  = false;
                }
             
            }
            
        }
    }

    void SendNewPos(Vector3 pos)
    {
        position = pos;
        newPosition = true;
    }

    void OnDestroy()
    {
        threadRunning = false;
        if (thread != null && thread.IsAlive)
        {
            thread.Interrupt();
            thread.Join();
        }
        NetMQConfig.Cleanup();
        RayPosTracker.NotifyPos -= SendNewPos; 
    }

}