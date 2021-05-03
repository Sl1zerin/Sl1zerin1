using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTap : MonoBehaviour {
	public GameObject FPScharacter;

	void start (){



	}

	void Update (){
		gameObject.transform.LookAt (FPScharacter.transform.position);
	}
}