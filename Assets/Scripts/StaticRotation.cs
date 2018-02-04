using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticRotation : MonoBehaviour {

	#region Variables
	private Quaternion rot;//rotacion inicial
	#endregion


	#region Custom Methods

	#endregion


	#region Unity Methods
	void Start () 
	{
		rot = transform.rotation;
	}
	
	
	void LateUpdate () 
	{
		transform.rotation = rot;
	}

	#endregion
}
