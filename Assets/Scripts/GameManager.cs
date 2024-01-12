using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private void OnGUI()
	{
		if( Coockie.Count == 0 )
		{
			GUIStyle style = new GUIStyle();
			style.fontSize = 32;
			style.alignment = TextAnchor.MiddleCenter;
			style.fontStyle = FontStyle.BoldAndItalic;
			style.normal.textColor = Color.white;
			Rect rect = new Rect(0,0,128, 32);
			string text = "clear";
			GUI.Label(rect, text, style);
		}
	}
}
