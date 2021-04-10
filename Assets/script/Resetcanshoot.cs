using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetcanshoot : MonoBehaviour // 當子彈廢除屏幕時將可以發射下一發子彈
{
    public Move A;
    public void Res(){
        A.canshoot = true;
    }
}
