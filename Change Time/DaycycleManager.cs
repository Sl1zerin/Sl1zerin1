using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaycycleManager : MonoBehaviour {

	[Range(0,1)]
	public float TimeOfDay;
	public float DayDuration = 600f;

	public AnimationCurve SunCurve;
	public AnimationCurve MoonCurve;
	public AnimationCurve SkyboxCurve;

	public Material DaySkybox;
	public Material NigthSkybox;

	public ParticleSystem Stars;

	public Light Sun;
	public Light Moon;

	private float sunIntensity;
	private float moonIntensity;

	// Use this for initialization
	private void Start () {

		sunIntensity = Sun.intensity;
		moonIntensity = Moon.intensity;
	}
	
	// Update is called once per frame
	private void Update () {

		TimeOfDay += Time.deltaTime / DayDuration;
		if (TimeOfDay >= 1) TimeOfDay -= 1;

		RenderSettings.skybox.Lerp (NigthSkybox, DaySkybox, SkyboxCurve.Evaluate (TimeOfDay));
		RenderSettings.sun = SkyboxCurve.Evaluate (TimeOfDay) > 0.1F ? Sun : Moon;
		DynamicGI.UpdateEnvironment ();

		var mainModule =  Stars.main;
		mainModule.startColor = new Color (1, 1, 1, 1 - SkyboxCurve.Evaluate (TimeOfDay));

		Sun.transform.localRotation = Quaternion.Euler (TimeOfDay * 360f, 180, 0);
		Moon.transform.localRotation = Quaternion.Euler (TimeOfDay * 360f + 180f, 180, 0);

		Sun.intensity = sunIntensity * SunCurve.Evaluate (TimeOfDay);
		Moon.intensity = moonIntensity * MoonCurve.Evaluate (TimeOfDay);
	}
}
