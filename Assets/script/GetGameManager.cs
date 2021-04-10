using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameManager : MonoBehaviour // 敵人取得 Gmanager
{
    public GManager g;
    public static GManager A;
    private void Start() {
        if(g != null){
            A = g;
        }
        
    }
    public GManager Get(){
        return A;
    }
}
