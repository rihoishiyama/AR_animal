using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class gameOver : MonoBehaviour {
	
	[SerializeField] private EditorHitTest eht;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		eht.gameState = EditorHitTest.GameState.Play;
	}
}
