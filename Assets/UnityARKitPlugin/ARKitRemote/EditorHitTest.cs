using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.XR.iOS
{

	public class EditorHitTest : MonoBehaviour {

//		public Transform m_HitTransform;
		[SerializeField] private DestroyAnimal da;

		public float maxRayDistance = 30.0f;
		public LayerMask collisionLayerMask;
		public Camera cam;
		public GameObject[] animals = new GameObject[5];
		private int createAnimals = 0;
		public bool gameOverFlag = false;
		[SerializeField] private Text scoreText;
		[SerializeField] private GameObject gameStart;
		[SerializeField] private GameObject gameOver;
		private GameObject animal;
		private int score = 0;
//		private bool isTouchScreen = false;
//		private System.TimeSpan allowTime = new System.TimeSpan(0, 0, 1);
//		private System.TimeSpan pastTime;
//		private System.DateTime reloadTime;

		public GameState gameState;
		public Text initText;

		public enum GameState
		{
			Start,
			Play,
			Finish,
			Init
		}

		void Start(){
//			reloadTime = System.DateTime.Now;
		}
			
		void Update () {

			switch (gameState) 
			{
			case GameState.Start:
				gameStart.SetActive (true);
				gameOver.SetActive (false);

				break;

			case GameState.Play:
				gameStart.SetActive (false);
				if (Input.GetMouseButtonDown (0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !gameOverFlag) {
//					if ( isTouchScreen ) return;
//					isTouchScreen = true;
					animal = Instantiate (animals [Random.Range (0, 5)]);
					animal.transform.position = cam.transform.TransformPoint (0, 0, 0.5f);
					animal.GetComponent<Rigidbody> ().AddForce (cam.transform.TransformDirection (0, 1f, 2f), ForceMode.Impulse);
					createAnimals++;
//					this.reloadTime = System.DateTime.Now;
				}
				if (gameOverFlag) {
					gameState = GameState.Finish;
				}

				break;

			case GameState.Finish:
				score = createAnimals - da.destroy;
				gameOver.SetActive (true);
				scoreText.text = score.ToString ();


				break;

			case GameState.Init:
				score = 0;
				createAnimals = 0;
				da.destroy = 0;
				gameOverFlag = false;
				InitAnimals ();
				Application.LoadLevel("UnityARKitScene");
				gameState = GameState.Start;

				break;

			}

//			if (isTouchScreen) {
//				pastTime = System.DateTime.Now - this.reloadTime;
//				if(pastTime > allowTime){
//					isTouchScreen = false;
//				}
//			}

		}

		private void InitAnimals(){
			GameObject[] buffer = GameObject.FindGameObjectsWithTag("animal");
			foreach (GameObject ani in buffer) {
				Destroy(ani);

			}
		}
	}
}
