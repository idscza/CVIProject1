using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarita : MonoBehaviour
{
    // Start is called before the first frame update
	
	float elapsedTime;

    void Start()
    {
		Matrix4x4 obl = Camera.main.projectionMatrix;
		//Encuadre de cámara
		obl[0, 2] = -0.7f;
		obl[1, 2] = -1.5f;
		//Traslación de cámara
		obl[0, 3] = -4f;
		obl[1, 3] = -11f;
		obl[2, 3] = -10f;
		Camera.main.projectionMatrix = obl;
    }
	

}
