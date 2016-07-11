using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;       //シーン遷移に使用

public class Player : MonoBehaviour {

	public float m_speed = 4f;     //スピード
	private Rigidbody2D m_rigidbody;
	public GameObject m_mainCamera;

	private int m_jump = 2;        //ジャンプの回数

	// Use this for initialization
	void Start () {

		m_rigidbody = GetComponent<Rigidbody2D> ();
		m_mainCamera = GameObject.Find ("Main Camera");

		//カメラの位置取得
		Vector3 cameraPos = m_mainCamera.transform.position;
		//Playerの位置から4つ移動した位置を画面中央に
		cameraPos.x = transform.position.x + 1;
		cameraPos.y = transform.position.y + 1;
		m_mainCamera.transform.position = cameraPos;
	
	}
		

	void Update(){

		//spaceキーを押したら
		if (Input.GetKeyDown ("space")) {
			if (m_jump > 0) {
				this.m_rigidbody.velocity = Vector3.up * 8.0f;
				m_jump--;
			}
		}
	}

	//地面との当たり判定処理
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground") {
			//二回飛べる制限がリセット
			m_jump = 2;
		}
	}

	void FixedUpdate(){

		float x = Input.GetAxisRaw ("Horizontal");


		//画面中央からPlayerが4方向に移動したら
		if (transform.position.x > m_mainCamera.transform.position.x - 4) {
			//カメラ位置を取得
			Vector3 cameraPos = m_mainCamera.transform.position;
			//Playerの位置から右に4つ移動した位置を画面中央に
			cameraPos.x = transform.position.x + 1;
			m_mainCamera.transform.position = cameraPos;
		}

		if (transform.position.y > m_mainCamera.transform.position.y - 4) {
			Vector3 cameraPos = m_mainCamera.transform.position;
			cameraPos.y = transform.position.y + 1;
			m_mainCamera.transform.position = cameraPos;
		}

		//入力方向へ移動
		if (x != 0) {
			m_rigidbody.velocity = new Vector2 (x * m_speed, m_rigidbody.velocity.y);

			//画像を反転させる
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;


			//カメラ表示領域の左下をワールド座標に変換
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			//カメラ表示領域の右下をワールド座標に変換
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			//Playerの位置を取得
			Vector2 pos = transform.position;
			pos.x = Mathf.Clamp (pos.x, min.x + 0.5f, max.x);
			transform.position = pos;


			//キー入力がなければ止まる
		} else {
			m_rigidbody.velocity = new Vector2 (0, m_rigidbody.velocity.y);

		}

	}

    //障害物に当たったときの処理
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Garlic" || other.tag == "Cross")
        {
            //プレイヤーが消える
            //Destroy(gameObject);

            //タイトルシーンに遷移
            SceneManager.LoadScene("Title");
        }
    }
}
