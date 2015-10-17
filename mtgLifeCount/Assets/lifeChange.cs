using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lifeChange : MonoBehaviour {
	public Text life;
	
	public void IncrementFive (){
		int curLife;
		int.TryParse (life.text, out curLife);
		life.text = (curLife + 5).ToString();
	}
	public void IncrementOne (){
		int curLife;
		int.TryParse (life.text, out curLife);
		life.text = (curLife + 1).ToString();
	}
	
	public void DecrementFive(){
		int curLife;
		int.TryParse (life.text, out curLife);
		life.text = (curLife - 5).ToString();
	}
	public void DecrementOne(){
		int curLife;
		int.TryParse (life.text, out curLife);
		life.text = (curLife - 1).ToString();
	}
}
