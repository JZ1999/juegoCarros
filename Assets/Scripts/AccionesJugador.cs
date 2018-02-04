using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesJugador : MonoBehaviour {

	#region Variables
	private Vector3 VectorDelMouse;
	private float tiempo;//Tiempo para poner otro camino
	public GameObject camino;
	private Vector3 dir;//Hacia donda apunta el camino
	private bool mouseDown;
	private bool listo;



	/*
	0 = arriba
	1 = Centro
	2 = Abajo
	*/
	enum Caminos
	{
		Arriba,
		Centro,
		Abajo
	}
	#endregion


	#region Custom Methods
	int Inputs_Calcular ()
	{
		int TipoDeCamino = 0;//El default es 0, a un angulo de 15° en el eje X

		if (Input.GetKeyDown (KeyCode.Q)) {
			TipoDeCamino = (int)Caminos.Arriba;
			Debug.Log("q");

		} else if (Input.GetKeyDown (KeyCode.W)) 
		{
			TipoDeCamino = (int)Caminos.Centro;
			Debug.Log("w");

		} else if(Input.GetKeyDown (KeyCode.E))
		{
			TipoDeCamino = (int)Caminos.Abajo;
			Debug.Log("e");

		}
		return TipoDeCamino;

	}

	Vector3 CalcularDirrecion (int valor)//valor es 0 1 ó 2
	{
		Debug.Log("Calc");
		switch (valor) 
		{
			case 0:
				return new Vector3(15,0,0);
			case 1:
				return Vector3.zero;
			case 2:
				return new Vector3(-15,0,0);

		}
		Debug.Log("ERROR001:\n\tCalcularDireccion tiene el parámetro \"valor\" malo.");
		return Vector3.zero;

	}
	#endregion


	#region Unity Methods
	void Start () 
	{
		tiempo = 2f;
		mouseDown = false;
	}
	
	
	void Update ()
	{
		
		listo = tiempo <= 0;//listo para poner otro camino
		mouseDown = Input.GetMouseButtonDown(0);//Click izquierdo
		int input_usr = Inputs_Calcular();//Detecta si le das q w ó e
		if (mouseDown && listo) 
		{

		dir = CalcularDirrecion(input_usr);
		PonerCamino();
		}
		tiempo-=Time.deltaTime;
	}

	void PonerCamino ()
	{
		VectorDelMouse = Input.mousePosition;
		mouseDown = true;
		Debug.Log("Mouse");
		if (listo) 
		{
			mouseDown = false;
			Debug.Log("Mouse 2");
			//Debug.Log(VectorDelMouse.ToString());
			GameObject obj = Instantiate (camino,VectorDelMouse,Quaternion.Euler(dir));
			obj.transform.position = new Vector3(0,1,obj.transform.position.z+2f);
			tiempo = 2;

		}

	}

	#endregion
}
