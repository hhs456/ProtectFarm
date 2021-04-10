using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValue : MonoBehaviour // 初始化音量
{
    public string Name;
    void Start()
    {
        GetComponent<UnityEngine.UI.Slider>().value = PlayerPrefs.GetFloat("music");
        Destroy(this);
    }

}
