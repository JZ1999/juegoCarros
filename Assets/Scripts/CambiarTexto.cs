using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarTexto : MonoBehaviour {

	#region Variables
	public GameObject player;
	private int puntos;
	public Text obj;
	private ComerItem script;
	#endregion


	#region Custom Methods

	#endregion


	#region Unity Methods
	void Start () 
	{
		script = player.GetComponent<ComerItem>();
		puntos = script.GetPuntos();
	}
	

	void Update () 
	{
		puntos = script.GetPuntos();
		obj.text = puntos.ToString();
	}

	#endregion
}
