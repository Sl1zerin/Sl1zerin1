using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject prefabjeans;
	public GameObject prefabbody;
	public SkinnedMeshRenderer playerSkin;
	public bool haveJuns;
	public bool havebody;
	public GameObject juns;
	public GameObject body;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.R))
		{
			if (!haveJuns) {
				addWear (prefabjeans);
			}
		}
		if(Input.GetKeyUp(KeyCode.X))
			{
			if (haveJuns) {
				Destroy (juns);
				haveJuns = false;
			}
			}
		if (Input.GetKeyUp (KeyCode.T)) {
			if (!havebody) {
				addWears (prefabbody);
			}
		}
		if (Input.GetKeyUp (KeyCode.C)) {
			if (havebody) {
				Destroy (body);
				havebody = false;
			}
		}
	}

	void addWear (GameObject prefab)
	{
		juns = Instantiate<GameObject> (prefab);
		haveJuns = true;
				juns.transform.SetParent (playerSkin.transform.parent);
		SkinnedMeshRenderer[] renderers = juns.GetComponentsInChildren<SkinnedMeshRenderer> (prefabjeans);
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