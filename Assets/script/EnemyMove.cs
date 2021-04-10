using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour //敵人的移動
{
    public float speed;
    int a = 1;
    public GameObject Bullet;
    GManager A;
    public int ItemNum = 0;   // 0 baihgui, 1 tomruulah, 2 daraalj buudah, 3 tsatsah  
    // 道具的編號: 0 - 不是道具, 1 - 放大, 2 - 連發, 3 - 散彈
    void Start()
    {
        if (transform.position.x > 0)
        {
            if (ItemNum == 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            a = -1;
        }
        A = GetComponent<GetGameManager>().Get();
    }
    public float targettime;
    public int score;
    float count = 0;
    public bool isbee;
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * a * speed * Time.fixedDeltaTime * A.timebonus);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
