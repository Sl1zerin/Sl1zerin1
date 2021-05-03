using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KepUp : MonoBehaviour {

	public SkinnedMeshRenderer playerSkin;
	public GameObject body1;
	public GameObject weapon2;
	public GameObject trigger;
	public GameObject F;
	public GameObject body;
	public bool havebody;
	public GameObject prefabbody;

	void OnTriggerStay (Collider Other) {
		F.SetActive (true);
		if (Input.GetKeyUp(KeyCode.F)){
			if (!havebody) {
				addWears (prefabbody);
				body1.SetActive (false);
				F.SetActive (false);
			}
		}

	}
	void OnTriggerExit (Collider other){
		F.SetActive (false);
	}
	void start () {

	}
	void Update () {
		if (Input.GetKeyUp (KeyCode.G)) {
			if (havebody) {
				Destroy (body);
				havebody = (false);
			}
		}
	}
void addWears (GameObject prefabs)
{
	body = Instantiate<GameObject> (prefabs);
	havebody = true;
	body.transform.SetParent (playerSkin.transform.parent);
	SkinnedMeshRenderer[] renderers = body.GetComponentsInChildren<SkinnedMeshRenderer> (prefabbody);
	if (renderers.Length > 0) {
		{
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers [i].bones = playerSkin.bones;
				renderers [i].rootBone = playerSkin.rootBone;
			}
		}
	}
}
}