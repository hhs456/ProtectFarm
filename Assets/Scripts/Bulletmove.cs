using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour {
    public float speed;
    public GManager A;
    public AudioSource hitEnermy;
    public AudioSource hitItem;
    int x = 0;
    private void Start() {
        A = GetComponent<GetGameManager>().Get();
        hitEnermy = A.hitEnermy;
        hitItem = A.hitItem;
        this.transform.localScale = A.Tomruulah;
    }
    void FixedUpdate() {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        switch (other.gameObject.tag) {
            case "wall":
                if (speed > 0)
                    other.gameObject.GetComponent<Resetcanshoot>().Res();
                Destroy(this.gameObject);
                break;
            case "bullet":
                if (other.gameObject.GetComponent<Bulletmove>().speed < 0)
                    Destroy(other.gameObject);
                break;
            case "Player":
                if (speed < 0) {
                    A.OnHealthPointChanged(1);
                    Destroy(this.gameObject);
                }
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        EnemyMove enemyMove = other.gameObject.GetComponent<EnemyMove>();
        switch (other.gameObject.tag) {
            case "enemy":
                if (speed > 0) {
                    if (enemyMove.ItemNum == 0) {
                        x++;
                        A.Hit(enemyMove.score, x);
                        hitEnermy.Play();
                        other.gameObject.GetComponent<Animator>().Play("Destory");
                        other.gameObject.GetComponent<Collider2D>().enabled = false;
                    }
                    else {
                        A.GetItem(enemyMove.ItemNum);
                        hitItem.Play();
                        Destroy(other.gameObject);
                    }

                }
                break;
            case "bee":
                if (speed > 0) {
                    A.Hit(enemyMove.score, x);
                    hitEnermy.Play();
                    other.gameObject.GetComponent<Animator>().Play("Destory");
                    other.gameObject.GetComponent<Collider2D>().enabled = false;
                    //A.HpChange(-1);
                    A.gameTime += 10;
                }
                break;
            default:
                break;
        }
    }
}
