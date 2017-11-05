using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChar : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
	text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PrintOnScreen(Character i)	
	{
		text.text = "Nome: " + i.Nome + System.Environment.NewLine +
					"Descrição: " + i.Descricao + System.Environment.NewLine +
					"Sexo: " + i.Sexo + System.Environment.NewLine +
					"Planeta: " + i.Planeta + System.Environment.NewLine;
	}
}
