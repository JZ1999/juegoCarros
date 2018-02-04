using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAcciones : MonoBehaviour {

	#region Variables
	private int puntos;
	public AudioClip shootSound;
	public AudioSource source;

	private Rigidbody rb;
	private Vector3 vector;//Vector para la direccion del runner
	private int speed;
	#endregion


	#region Custom Methods
	//Se ocupa esta funcion para enseñar los puntos en otro objeto
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

		rb = GetComponent<Rigidbody>();
		vector = Vector3.forward;
		speed = 5;
	}
	
	
	void Update () 
	{
		//rb.AddForce(vector*Time.deltaTime*speed);
		transform.Translate(vector*Time.deltaTime*speed);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Item_Dona")) 
		{
			source.Play();
			puntos++;
			puntos/=2;
			Destroy(other.gameObject);
			//Debug.Log(puntos);
		}

	}

	#endregion
}
