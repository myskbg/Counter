using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	private void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize= 18;
		style.alignment = TextAnchor.MiddleCenter;
		float width = 128;
		float height = 32;

		Rect rect = new Rect(Screen.width - width, Screen.height - height, width, height);
		string text = "Minigame";
		GUI.Label(rect, text, style);
		Rect rect2 = new Rect(rect);
		rect2.y -= 60;
		bool result = GUI.Button(rect2, "Start");
		if( result != false)
		{
			SceneManager.LoadScene	("Coffee Icons");
		}
	}
}
