using UnityEngine;
using System.Collections;

public class Garlic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//プレイヤーに当たると一緒に消え,地面に当たっても消える
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" || other.tag == "Ground")
		{
			Destroy(gameObject);
		}
	}
}
