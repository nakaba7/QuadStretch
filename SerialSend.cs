using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialSend : MonoBehaviour
{
    //SerialHandler.c�̃N���X
    /*public SerialHandler serialHandler;
    int i = 0;

    void Update() //������0.001�b���ƂɎ��s�����
    {
        if(Input.GetKeyDown(KeyCode.A)) {
			Debug.Log("Send message " + Input.mousePosition.x);
			serialHandler.Write(Input.mousePosition.x.ToString() + "\0");
		}
    }*/
    //SerialHandler.c�̃N���X
    public SerialHandle serialHandler;
    public bool arrowflag;
    int i = 0;

    void Start()
    {
        //�M������M�����Ƃ��ɁA���̃��b�Z�[�W�̏������s��
        serialHandler.OnDataReceived += OnDataReceived;
        arrowflag = false;
    }

    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        var data = message.Split(
                new string[] { "\n" }, System.StringSplitOptions.None);
        try
        {
            Debug.Log(data[0]);//Unity�̃R���\�[���Ɏ�M�f�[�^��\��
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);//�G���[��\��
        }
    }

    void FixedUpdate() //������0.001�b���ƂɎ��s�����
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