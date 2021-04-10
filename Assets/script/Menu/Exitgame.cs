using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitgame : MonoBehaviour // 主畫面
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Link(string a){ // 超鏈接
        Application.OpenURL(a);
    }
}
