using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Player player;

    // 移動スピード
    public float speed = 5;

    void Update()
    {
        // 右・左
        float x = Input.GetAxisRaw("Horizontal");
        ;

        // 移動する向きを求める
        Vector2 direction = new Vector2(x, 0).normalized;

        // 移動する向きとスピードを代入する
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        // 移動の制限
        Clamp();
    }

    void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }


// ぶつかった瞬間に呼び出される
void OnTriggerEnter2D (Collider2D c)
{
 

    // プレイヤーを削除
    Destroy(gameObject);
}
}