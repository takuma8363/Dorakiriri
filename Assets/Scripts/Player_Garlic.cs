using UnityEngine;
using System.Collections;

public class Player_Garlic : MonoBehaviour
{

    public float m_speed = 4f;      //スピード
    private Rigidbody2D m_rigidbody;
    public GameObject m_mainCamera;

    // Use this for initialization
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        //入力方向へ移動
        if (x != 0)
        {
            m_rigidbody.velocity = new Vector2(x * m_speed, m_rigidbody.velocity.y);

            //画像を反転させる
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;

            //画面中央からPlayerが4方向に移動したら
            /*if (transform.position.x > m_mainCamera.transform.position.x - 4)
            {
                //カメラ位置を取得
                Vector3 cameraPos = m_mainCamera.transform.position;
                //Playerの位置から右に4つ移動した位置を画面中央に
                cameraPos.x = transform.position.x + 4;
                m_mainCamera.transform.position = cameraPos;
            }
            */

            //カメラ表示領域の左下をワールド座標に変換
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            //カメラ表示領域の右下をワールド座標に変換
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            //Playerの位置を取得
            Vector2 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
            transform.position = pos;

            //キー入力がなければ止まる
        }
        else
        {
            m_rigidbody.velocity = new Vector2(0, m_rigidbody.velocity.y);

        }
    }

    //にんにくに当たるとプレイヤーが消える
    //でもこれだとどのオブジェクトに当たっても消えるから改良が必要
    void OnTriggerEnter2D(Collider2D other)
    {
        //ここにif(にんにくに当たったら)を追加したらいけそうだけど、まだ動かないです
        Destroy(gameObject);
    }

}
