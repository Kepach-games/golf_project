using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaLoptice : MonoBehaviour {



    private LineRenderer linijaPravca;  // Linija indikatora pravca

	private Rigidbody2D rigb;  // 2D telo (fizika) loptice

	bool indikator_dodira = false;
    [SerializeField]
    private float speed;
	float startPosX;
	float krajPosX;
	float startPosY;
	float krajPosY;

	float brzina = 3;

	Vector2 tackaPom;

	void Start () {
		linijaPravca = GetComponent<LineRenderer>();
		linijaPravca.positionCount = 2;
		rigb = GetComponent<Rigidbody2D> ();
	}

    void Update () {
        if (rigb.IsAwake())
        {
            if ((speed = rigb.velocity.magnitude) < 0.45f)
                rigb.velocity=Vector2.zero; 
        }
	}
		
	void OnMouseDown() { 
		if (rigb.IsSleeping ()) { // IsSleeping proverava da li je loptica potpuno mirna da bi se novi potez mogao otpoceti
			linijaPravca.positionCount = 2;
			startPosX = Input.mousePosition.x;
			startPosY = Input.mousePosition.y;
			indikator_dodira = true;
		}
	}

	void OnMouseDrag () { // Potrebno je napraviti tako da indikator bude fiksne duzine, ali i da se odbija o zidove
		if (rigb.IsSleeping ()) {  
			Vector2 tackaPom = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			tackaPom.x = gameObject.transform.position.x * 2 - tackaPom.x;
			tackaPom.y = gameObject.transform.position.y * 2 - tackaPom.y;
			Vector3 lokacija = tackaPom;
			linijaPravca.SetPositions (new[] { gameObject.transform.position, lokacija });
		}
	}

	void OnMouseUp() {
    	if (indikator_dodira == true) {

			linijaPravca.positionCount = 0;

			krajPosX = Input.mousePosition.x;
			krajPosY = Input.mousePosition.y;

			float silaX = startPosX - krajPosX;
			float silaY = startPosY - krajPosY;

			tackaPom.x = silaX;
			tackaPom.y = silaY;

			rigb.AddForce(tackaPom * brzina);

			indikator_dodira = false;
		} 

		else {
			return;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		// Koristimo u slucaju da loptica dodirne prepreku


		//rigb.velocity = Vector2.zero;
	}
}
