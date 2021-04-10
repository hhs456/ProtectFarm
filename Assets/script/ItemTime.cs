using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTime : MonoBehaviour // 道具持續時間的管理
{
    public float time;
    public float count1 = 0;
    public float count2 = 0;
    public float count3 = 0;
    public GManager A;
    public bool item1 = false;
    public bool item2 = false;
    public bool item3 = false;
    public Slider I1, I2, I3;

    private void FixedUpdate()
    {
        if (item1)
        {
            count1 += Time.fixedDeltaTime;
            I1.value = count1;
            if (count1 >= time)
            {
                A.ItemOver(1);
                item1 = false;
                count1 = 0;
            }
        }
        if (item2)
        {
            count2 += Time.fixedDeltaTime;
            I2.value = count2;
            if (count2 >= time)
            {
                A.ItemOver(2);
                count2 = 0;
                item2 = false;
            }
        }
        if (item3)
        {
            count3 += Time.fixedDeltaTime;
            I3.value = count3;
            if (count3 >= time)
            {
                A.ItemOver(3);
                count3 = 0;
                item3 = false;
            }
        }
        if (!item1 && !item2 && !item3)
        {
            this.enabled = false;
        }
    }
}
