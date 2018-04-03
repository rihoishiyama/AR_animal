using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.UI;

public class DestroyAnimal : MonoBehaviour {
	[SerializeField] private EditorHitTest eht;
	public int destroy = 0;
	public Text destroyText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision other){
		destroy++;
		destroyText.text = destroy.ToString ();
		Destroy (other.gameObject);
		if (destroy >= 10) {
			eht.gameOverFlag = true;
		}
	}
}
