using UnityEngine;
using System.Collections;

public class Female : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    /*void Update () {
	
	}*/

    //プレイヤーに当たったら消える
    //Garlicのほうと同じで、これだとどのオブジェクトに当たっても消えてしまうので作り直します
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
