using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBullet : MonoBehaviour{

    PlayerBehaviour player;
    public Image B;
    private void Start()
    {
        player = GetComponent<PlayerBehaviour>();
    }
    public float targettime;
    float count = 0;
    public void ST(){
        this.enabled = true;
        B.gameObject.SetActive(true);
    }
    void Update()
    {
        count += Time.deltaTime;
        B.fillAmount = (float)(count / targettime);
        if (count >= targettime)
        {
            count = 0;
            player.A.BulletNum = player.A.MaxBullet;
            player.Blt.text = player.A.BulletNum + "/" + player.A.MaxBullet;
            this.enabled = false;
            player.Blt.color = player.NoBonus;
            B.gameObject.SetActive(false);
        }
    }
}
