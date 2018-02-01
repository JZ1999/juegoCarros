using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComerItem : MonoBehaviour {

	#region Variables
	private int puntos;
	public AudioClip shootSound;
	public AudioSource source;
	#endregion


	#region Custom Methods
	public int GetPuntos ()
	{
		return puntos;
	}
	#endregion


	#region Unity Methods
	void Start () 
	{
		puntos = 0;
		source.clip = shootSound;
	}
	
	
	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Item_Dona")) 
		{
			source.Play();
			puntos++;
			Destroy(other.gameObject);
			Debug.Log(puntos);
		}

	}

	#endregion
}
