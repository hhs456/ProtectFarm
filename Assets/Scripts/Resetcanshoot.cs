using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetcanshoot : MonoBehaviour
{
    public PlayerBehaviour player;
    public void Res(){
        player.isReadyToShoot = true;
    }
}
