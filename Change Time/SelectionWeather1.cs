using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectionWeather1 : MonoBehaviour {

	public DaycycleManager DayCoin;
	public Text Daycoin2;
	public Text Mountcoin2;
	public Text TimeText;
	[SerializeField]private float time;
	[SerializeField]private float Min =0;
	[SerializeField]private float Min1 =0;
	[SerializeField]private int hour =0;
	[SerializeField]private float DuractionTime;
	public float hoursDuraction;
	public float minDuraction;


	void Start (){

	}

	private void Update () {
		Daycoin2.GetComponent<Text> ().text = "Day:";
		Daycoin2.text += DayCoin.NumberDay.ToString ();
		Mountcoin2.GetComponent<Text> ().text = "Mount:";
		Mountcoin2.text += DayCoin.NumberMonth.ToString ();

		Min += Time.fixedDeltaTime;
		if (Min >= 1){
			Min = 0;
			Min1 += 1;
		}
		if (Min1 >= 60) {
			hour += 1;
			Min1 = 0;
		}
		if (hour >= 24) {
			Min1 = 0;
			hour = 0;
		}
		TimeText.GetComponent<Text> ().text = "Time:";
		TimeText.text += hour.ToString ();
		TimeText.GetComponent<Text> ().text += ":";
		TimeText.text += Min1.ToString ();
		}
	}