using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {
    public float speed;
    public GameObject Bullet;
    public GManager A;
    public GameObject Player;
    public GameObject CenterPlayer;
    public Text Blt;
    public Color Bonus;
    public Color NoBonus;
    public float minRot = -90f;
    public float maxRot = 90f;    

    public bool isReadyToShoot = true;
    public bool isItemUsed = false;
    public float targetTime = 0.1f;
    public Transform[] Sups;
    float count = 0;
    public bool itemMegaShoot = false;

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.A)) {
            if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 270) {
                transform.Rotate(new Vector3(0, 0, -speed));
            }
        }
        if (Input.GetKey(KeyCode.D)) {
            if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 270) {
                transform.Rotate(new Vector3(0, 0, speed));
            }
        }
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 180) {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 180) {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
    }

    private void Update() {
        if (!isItemUsed) {
            if (Input.GetKeyDown(KeyCode.Space) && isReadyToShoot) {
                if (A.BulletNum > 0) {
                    A.bulletbonus = 1.0f;
                    A.BulletNum--;
                    Blt.text = A.BulletNum + "/" + A.MaxBullet;
                    if (!itemMegaShoot) {
                        Instantiate(Bullet, CenterPlayer.transform.position, this.transform.rotation);
                    }
                    else {
                        int length = Sups.Length;
                        for(int i=0;i< length; i++) {
                            Instantiate(Bullet, Sups[i].position, Sups[i].rotation);
                        }
                    }
                    isReadyToShoot = false;
                    if (A.BulletNum == 0) {
                        this.GetComponent<ReloadBullet>().ST();
                        A.bulletbonus = 2.2f;
                    }
                    Blt.color = (A.BulletNum == 1) ? Bonus : Blt.color;
                }

            }
        }
        else {
            if (Input.GetKey(KeyCode.Space)) {
                count += Time.deltaTime;
                if (count >= targetTime) {
                    if (A.BulletNum > 0) {
                        A.bulletbonus = 1.0f;
                        A.BulletNum--;
                        Blt.text = A.BulletNum + "/" + A.MaxBullet;
                        if (!itemMegaShoot) {
                            Instantiate(Bullet, CenterPlayer.transform.position, this.transform.rotation);
                        }
                        else {
                            int length = Sups.Length;
                            for (int i = 0; i < length; i++) {
                                Instantiate(Bullet, Sups[i].position, Sups[i].rotation);
                            }
                        }
                        if (A.BulletNum == 0) {
                            this.GetComponent<ReloadBullet>().ST();
                            A.bulletbonus = 2.2f;
                        }
                        Blt.color = (A.BulletNum == 1) ? Bonus : Blt.color;
                    }
                    count = 0;
                }
            }
        }

    }
}
