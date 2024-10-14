using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

public class NewBehaviourScript : MonoBehaviour
{
    private string show;// ��ʾ������
    private string cal;// �����
    private double a;// �����
    private double b;// �Ҳ���
    private bool calculated;// ������һ�������������Ƿ��Ѿ����й���Ӧ������
    private bool dot;// ��ǰ�����Ƿ����С����
    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ������
        Init();
    }

    void Init()
    {
        show = "0";
        cal = "NONE";
        calculated = true;
        dot = false;
        a = 0;
        b = 0;
    }

    void OnGUI()
    {
        // �жϵ�ǰ�����Ƿ�ΪС��
        dot = show.Contains(".");
        // ���Ƽ�����
        GUI.Box(new Rect(100, 25, 300, 340), "");
        GUI.Box(new Rect(130, 40, 240, 50), "\n" + show);
        // ���ư���������䴥�����¼�
        if (GUI.Button(new Rect(130, 100, 120, 50), "\nReset"))
            Init();
        if (GUI.Button(new Rect(250, 100, 60, 50), "\n%"))
        {
            double i = Convert.ToDouble(show);
            i = 0.01 * i;
            show = Convert.ToString(i);
        }
        if (GUI.Button(new Rect(310, 100, 60, 50), "\n��"))
        {
            calculate();
            double i = Convert.ToDouble(show);
            a = i;
            cal = "��";
            calculated = false;
            show = "0";
            dot = false;
        }
        if (GUI.Button(new Rect(130, 150, 60, 50), "\n7"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '7';
        }
        if (GUI.Button(new Rect(190, 150, 60, 50), "\n8"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '8';
        }
        if (GUI.Button(new Rect(250, 150, 60, 50), "\n9"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '9';
        }
        if (GUI.Button(new Rect(310, 150, 60, 50), "\nX"))
        {
            calculate();
            double i = Convert.ToDouble(show);
            a = i;
            cal = "X";
            calculated = false;
            show = "0";
            dot = false;
        }
        if (GUI.Button(new Rect(130, 200, 60, 50), "\n4"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '4';
        }
        if (GUI.Button(new Rect(190, 200, 60, 50), "\n5"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '5';
        }
        if (GUI.Button(new Rect(250, 200, 60, 50), "\n6"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '6';
        }
        if (GUI.Button(new Rect(310, 200, 60, 50), "\n��"))
        {
            calculate();
            double i = Convert.ToDouble(show);
            a = i;
            cal = "-";
            calculated = false;
            show = "0";
            dot = false;
        }
        if (GUI.Button(new Rect(130, 250, 60, 50), "\n1"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '1';
        }
        if (GUI.Button(new Rect(190, 250, 60, 50), "\n2"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '2';
        }
        if (GUI.Button(new Rect(250, 250, 60, 50), "\n3"))
        {
            if (show.Length >= 3 && show.Substring(show.Length - 2, 2) == ".0")
                show = show.Remove(show.Length - 1, 1);
            if (show == "0") show = "";
            show = show + '3';
        }
        if (GUI.Button(new Rect(310, 250, 60, 50), "\n+"))
        {
            calculate();
            double i = Convert.ToDouble(show);
            a = i;
            cal = "+";
            calculated = false;
            show = "0";
            dot = false;
        }
        if (GUI.Button(new Rect(130, 300, 120, 50), "\n0"))
        {
            if (show == "0") show = "";
            show = show + '0';
        }
        if (GUI.Button(new Rect(250, 300, 60, 50), "\n."))
        {
            if (dot == false)
            {
                show = show + ".0";
                dot = true;
            }
        }
        if (GUI.Button(new Rect(310, 300, 60, 50), "\n="))
        {
            calculate();
        }
    }


    void calculate()
    {// ��������ĺ���
        if (calculated == true)
            return;
        double sum = 0;
        double j = Convert.ToDouble(show);
        b = j;
        if (cal == "+")
            sum = a + b;
        if (cal == "-")
            sum = a - b;
        if (cal == "X")
            sum = a * b;
        if (cal == "��" && b != 0)
            sum = a / b;
        a = sum;
        b = 0;
        show = Convert.ToString(a);
        calculated = true;
    }


    /*// Update is called once per frame
    void Update()
    {
        
    }*/
}
