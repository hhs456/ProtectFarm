using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour // 子彈移動
{
    public float speed;
    public GManager A;
    int x = 0;
    private void Start()
    {
        A = GetComponent<GetGameManager>().Get();
        this.transform.localScale = A.Tomruulah;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            other.gameObject.GetComponent<Resetcanshoot>().Res();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (other.gameObject.GetComponent<EnemyMove>().ItemNum == 0) // 敵人
            {
                x++;
                Destroy(other.gameObject);
                A.Hit(other.gameObject.GetComponent<EnemyMove>().score, x);
            }
            else // 道具
            {
                A.GetItem(other.gameObject.GetComponent<EnemyMove>().ItemNum);
                Destroy(other.gameObject);
            }


        }
        else if (other.gameObject.CompareTag("bee")) // 蜜蜂
        {
            A.Hit(other.gameObject.GetComponent<EnemyMove>().score, x);
            Destroy(other.gameObject);
            A.gameTime += 10;

        }
    }
}
