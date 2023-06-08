using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialSend : MonoBehaviour
{
    //SerialHandler.cのクラス
    /*public SerialHandler serialHandler;
    int i = 0;

    void Update() //ここは0.001秒ごとに実行される
    {
        if(Input.GetKeyDown(KeyCode.A)) {
			Debug.Log("Send message " + Input.mousePosition.x);
			serialHandler.Write(Input.mousePosition.x.ToString() + "\0");
		}
    }*/
    //SerialHandler.cのクラス
    public SerialHandle serialHandler;
    public bool arrowflag;
    int i = 0;

    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        serialHandler.OnDataReceived += OnDataReceived;
        arrowflag = false;
    }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        try
        {
            Debug.Log(data[0]);//Unityのコンソールに受信データを表示
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//エラーを表示
        }
    }

    void FixedUpdate() //ここは0.001秒ごとに実行される
    {

        if (arrowflag)
        {
            serialHandler.Write("1");
            Debug.Log("A");
        }
        else
        {
            serialHandler.Write("0");
            Debug.Log("B");
        }
    }
}