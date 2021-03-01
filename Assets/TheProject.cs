using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheProject : MonoBehaviour
{
	public GameObject rojoalfa;
	public GameObject azulalfa;
	public GameObject manoroja;
	public GameObject manoazul;
	public GameObject cabezaroja;
	public GameObject sangre;
	public int phase = 0;
	public float elapsedTime;
    
	// Start is called before the first frame update
    void Start()
    {
		GameObject piso = create_soil();
		rock_me(50, piso);
		pipol();
        fighters();
		blood ();
    }
	
	GameObject create_soil()
	{
		GameObject plane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
		plane.transform.localScale = new Vector3 (10, 1, 10);
		var planeRenderer = plane.GetComponent<Renderer>();
		Color soilColor = new Color(0.863f, 0.753f, 0.545f, 0.7f);
		planeRenderer.material.SetColor("_Color", soilColor);
		
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3 (10, 0.1f, 10);
		var cubeRenderer = cube.GetComponent<Renderer>();
		cubeRenderer.material.SetColor("_Color", Color.black);
		cube.transform.parent = plane.transform;
		
		GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube1.transform.localScale = new Vector3 (9.5f, 0.11f, 9.5f);
		var cube1Renderer = cube1.GetComponent<Renderer>();
		Color arenaColor = new Color(0.396f, 0.263f, 0.129f, 0.7f);
		cube1Renderer.material.SetColor("_Color",arenaColor);
		cube1.transform.parent = cube.transform;
		
		GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube2.transform.localScale = new Vector3 (9.5f, 0.12f, 0.5f);
		var cube2Renderer = cube2.GetComponent<Renderer>();
		cube2Renderer.material.SetColor("_Color", Color.black);
		cube2.transform.parent = cube.transform;
		
		GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		cylinder.transform.localScale = new Vector3 (2, 0.065f, 2);
		var cylinderRenderer = cylinder.GetComponent<Renderer>();
		cylinderRenderer.material.SetColor("_Color", Color.black);
		cylinder.transform.parent = cube.transform;
		
		return plane;
	}
	
	void rock_me(int rocas, GameObject elpiso)
	{
		int count = 1;
		while (count <= rocas)
		{
			Vector3 place = create_cords();
			
			GameObject rocap1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			rocap1.transform.position = place;
			rocap1.transform.localScale = new Vector3 (0.5f, 0.75f, 0.5f);
			var rocap1Renderer = rocap1.GetComponent<Renderer>();
			rocap1Renderer.material.SetColor("_Color", Color.gray);
			rocap1.transform.parent = elpiso.transform;
			
			float orient = Random.Range(0f, 3.99f);
			Vector3 place2 = new Vector3(place.x, place.y, place.z);
			Vector3 rot = new Vector3(place.x, place.y, place.z);
			if (orient < 1){
				place2 = new Vector3(place.x-0.2f, place.y, place.z);
				rot = new Vector3 (0.6f, 0.4f, 0.35f);
			}else if (orient < 2){
				place2 = new Vector3(place.x+0.2f, place.y, place.z);
				rot = new Vector3 (0.6f, 0.4f, 0.35f);
			}else if (orient < 3){
				place2 = new Vector3(place.x, place.y, place.z-0.2f);
				rot = new Vector3 (0.35f, 0.4f, 0.6f);
			}else if (orient < 4){
				place2 = new Vector3(place.x, place.y, place.z+0.2f);
				rot = new Vector3 (0.35f, 0.4f, 0.6f);
			}
		
			GameObject rocap2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			rocap2.transform.position = place2;
			rocap2.transform.localScale = rot;
			var rocap2Renderer = rocap2.GetComponent<Renderer>();
			rocap2Renderer.material.SetColor("_Color", Color.gray);
			rocap2.transform.parent = rocap1.transform;
			
			count = count + 1;
		}
		
	}
	
	Vector3 create_cords()
	{
		float elz = Random.Range(-45.0f, 45.0f);
		float elx = Random.Range(-45.0f, 45.0f);
		Vector3 coords = new Vector3 (elx, 0, elz);
		while (elz*elx < 49 && elz*elx > -49)
		{
			elz = Random.Range(-45.0f, 45.0f);
			elx = Random.Range(-45.0f, 45.0f);
			coords = new Vector3 (elx, 0, elz);
		}			
		return coords;
	}
	
	void pipol(){
		
		int xstart = -6;
		int zstart = 5;
		int onde = 1;
		bool done = false;
		
		while(!done){
			create_person(new Vector3(xstart,0,zstart), onde, new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
			zstart = zstart-1;
			if(zstart < -5){
				done = true;
				xstart = xstart+1;
				onde = 0;
			}
		}
		
		done = false;
		
		while(!done){
			create_person(new Vector3(xstart,0,zstart), onde, new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
			xstart = xstart+1;
			if(xstart > 5){
				done = true;
				zstart = zstart+1;
				onde = 1;
			}
		}
		
		done = false;
		
		while(!done){
			create_person(new Vector3(xstart,0,zstart), onde, new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
			zstart = zstart+1;
			if(zstart > 5){
				done = true;
				xstart = xstart-1;
				onde = 0;
			}
		}
		
		done = false;
		
		while(!done){
			create_person(new Vector3(xstart,0,zstart), onde, new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
			xstart = xstart-1;
			if(xstart < -5){
				done = true;
			}
		}
	}
	
	GameObject create_person(Vector3 pos, int ori, Color ropita)
	{
		
		Vector3 legsize = new Vector3(0.25f, 0.5f, 0.25f);
		
		GameObject tronco = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		tronco.transform.localScale = new Vector3(0.6f, 0.75f, 0.6f);
		tronco.transform.position = new Vector3(pos.x, pos.y+1.4f, pos.z);
		var elRenderer3 = tronco.GetComponent<Renderer>();
		elRenderer3.material.SetColor("_Color", ropita);
		
		if (ori == 1)
		{
			GameObject pierna1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			pierna1.transform.localScale = legsize;
			pierna1.transform.position = new Vector3(pos.x, pos.y+0.5f, pos.z+0.17f);
			var elRenderer1 = pierna1.GetComponent<Renderer>();
			elRenderer1.material.SetColor("_Color", ropita);
			pierna1.transform.parent = tronco.transform;
			
			GameObject pierna2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			pierna2.transform.localScale = legsize;
			pierna2.transform.position = new Vector3(pos.x, pos.y+0.5f, pos.z-0.17f);
			var elRenderer2 = pierna2.GetComponent<Renderer>();
			elRenderer2.material.SetColor("_Color", ropita);
			pierna2.transform.parent = tronco.transform;
			
		}else{
			GameObject pierna1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			pierna1.transform.localScale = legsize;
			pierna1.transform.position = new Vector3(pos.x+0.17f, pos.y+0.5f, pos.z);
			var elRenderer1 = pierna1.GetComponent<Renderer>();
			elRenderer1.material.SetColor("_Color", ropita);
			pierna1.transform.parent = tronco.transform;
			
			GameObject pierna2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			pierna2.transform.localScale = legsize;
			pierna2.transform.position = new Vector3(pos.x-0.17f, pos.y+0.5f, pos.z);
			var elRenderer2 = pierna2.GetComponent<Renderer>();
			elRenderer2.material.SetColor("_Color", ropita);
			pierna2.transform.parent = tronco.transform;
		}
		
		GameObject cabeza = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		cabeza.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
		cabeza.transform.position = new Vector3(pos.x, pos.y+2.3f, pos.z);
		var elRenderer4 = cabeza.GetComponent<Renderer>();
		Color piel = new Color(0.351f, 0.217f, 0.164f, 1f);
		elRenderer4.material.SetColor("_Color", piel);
		cabeza.transform.parent = tronco.transform;
		cabezaroja = cabeza;
		
		return tronco;
		
	}
	
	void fighters(){
		
		Vector3 guerreroazul = new Vector3(0,0,2.5f);
		Vector3 guerrerorojo = new Vector3(0,0,-2.5f);		
		
		azulalfa = create_person(guerreroazul, 0, new Color(0f, 0.219f, 0.576f, 1f));
		rojoalfa = create_person(guerrerorojo, 0, new Color(0.807f, 0.066f, 0.148f, 1f));
		
		create_armor(guerreroazul,0, new Color(0f, 0.219f, 0.576f, 1f));
		
		create_armor(guerrerorojo,1, new Color(0.807f, 0.066f, 0.148f, 1f));
		
		
	}
	
	void create_armor(Vector3 pos, int ori, Color ropita){
	
		Vector3 ar1pos = new Vector3(pos.x+0.3f, pos.y+1.75f, pos.z-0.2f);
		var ar12rot = Quaternion.Euler(0,-45f,0);
		Vector3 ar2pos = new Vector3(pos.x+0.3f, pos.y+1.75f, pos.z-0.21f);
		Vector3 ar3pos = new Vector3(pos.x+0.3f, pos.y+1.465f, pos.z-0.2f);
		var ar34rot = Quaternion.Euler(0,-45f,-45f);
		Vector3 ar4pos = new Vector3(pos.x+0.3f, pos.y+1.465f, pos.z-0.21f);
			
		Vector3 manopos = new Vector3(pos.x-0.3f, pos.y+1.465f, pos.z);
		Vector3 espapos = new Vector3(pos.x-0.31f, pos.y+1.87f, pos.z-0.4f);
		var esparot = Quaternion.Euler(-45,0,0);

		
		if (ori != 0){
			
			ar1pos = new Vector3(pos.x-0.3f, pos.y+1.75f, pos.z+0.2f);
			ar12rot = Quaternion.Euler(0,-45f,0);
			ar2pos = new Vector3(pos.x-0.3f, pos.y+1.75f, pos.z+0.21f);
			ar3pos = new Vector3(pos.x-0.3f, pos.y+1.465f, pos.z+0.2f);
			ar34rot = Quaternion.Euler(0,-45f,-45f);
			ar4pos = new Vector3(pos.x-0.3f, pos.y+1.465f, pos.z+0.21f);
			
			manopos = new Vector3(pos.x+0.3f, pos.y+1.465f, pos.z);
			espapos = new Vector3(pos.x+0.31f, pos.y+1.87f, pos.z+0.4f);
			esparot = Quaternion.Euler(45,0,0);
			
		}
		
		GameObject armazon1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armazon1.transform.position = ar1pos;
		armazon1.transform.localScale = new Vector3 (0.6f, 0.6f, 0.01f);
		armazon1.transform.rotation = ar12rot;
		var armazon1Renderer3 = armazon1.GetComponent<Renderer>();
		armazon1Renderer3.material.SetColor("_Color",Color.black);
		
		GameObject armazon2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armazon2.transform.position = ar2pos;
		armazon2.transform.localScale = new Vector3 (0.55f, 0.55f, 0.01f);
		armazon2.transform.rotation = ar12rot;
		var armazon2Renderer3 = armazon2.GetComponent<Renderer>();
		armazon2Renderer3.material.SetColor("_Color",ropita);
		armazon2.transform.parent = armazon1.transform;
		
		GameObject armazon3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armazon3.transform.position = ar3pos;
		armazon3.transform.localScale = new Vector3 (0.424f, 0.424f, 0.01f);
		armazon3.transform.rotation = ar34rot;
		var armazon3Renderer3 = armazon3.GetComponent<Renderer>();
		armazon3Renderer3.material.SetColor("_Color",Color.black);
		armazon3.transform.parent = armazon1.transform;
		
		GameObject armazon4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        armazon4.transform.position = ar4pos;
		armazon4.transform.localScale = new Vector3 (0.374f, 0.374f, 0.01f);
		armazon4.transform.rotation = ar34rot;
		var armazon4Renderer3 = armazon4.GetComponent<Renderer>();
		armazon4Renderer3.material.SetColor("_Color",ropita);
		armazon4.transform.parent = armazon1.transform;
		
		GameObject mano = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		mano.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		mano.transform.position = manopos;
		var manoRenderer4 = mano.GetComponent<Renderer>();
		manoRenderer4.material.SetColor("_Color", ropita);
		
		GameObject espada = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		espada.transform.localScale = new Vector3(0.04f, 0.7f, 0.08f);
		espada.transform.position = espapos;
		espada.transform.rotation = esparot;
		Color acero = new Color(0.792f, 0.792f, 0.792f, 0.7f);
		var espadaRenderer2 = espada.GetComponent<Renderer>();
		espadaRenderer2.material.SetColor("_Color", acero);
		espada.transform.parent = mano.transform;
	
		if (ori == 0){
			mano.transform.parent = azulalfa.transform;
			armazon1.transform.parent = azulalfa.transform;
			manoazul = mano;
		}
		else{
			mano.transform.parent = rojoalfa.transform;
			armazon1.transform.parent = rojoalfa.transform;
			manoroja = mano;
		}
	}
	
	void blood(){
		GameObject blod = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		blod.transform.localScale = new Vector3 (0.1f, 0.10f, 0.1f);
		var blod1Renderer = blod.GetComponent<Renderer>();
		Color blodColor = new Color(0.4f, 0f, 0f, 0.7f);
		blod.transform.position = new Vector3 (0f, -1f, -2f);
		blod1Renderer.material.SetColor("_Color",blodColor);
		sangre = blod;
	}
	
	//animation goes here
	
	public float degs =0f;
	public float rotsped = 1000f;
	
	void Update(){
		
		Transform rojomove = rojoalfa.GetComponent<Transform>();
		Transform azulmove = azulalfa.GetComponent<Transform>();
		Transform mrmove = manoroja.GetComponent<Transform>();
		Transform mamove = manoazul.GetComponent<Transform>();
		Transform crmove = cabezaroja.GetComponent<Transform>();
		Transform smove = sangre.GetComponent<Transform>();
		elapsedTime += Time.deltaTime;
		
		if(phase == 0 && elapsedTime >= 4){
			rojomove.position += new Vector3(0f,0f,0.5f * Time.deltaTime);
			azulmove.position += new Vector3(0f,0f,-(0.5f * Time.deltaTime));
			if(rojomove.position.z >= -0.8){
				phase = 1;
			}
		}
		else if(phase == 1){
		

			float angle = -90f;
			float rate = -90.0f * 0.01f;
			
			mrmove.Rotate(Vector3.forward,rate);
			degs += rate;
			if (degs <= angle){
				float degs =0f;
				phase = 2;
			}

		}
		else if (phase == 2){
			 
			mrmove.position += new Vector3(0.7f * Time.deltaTime,0f,0.3f * Time.deltaTime);
			if(mrmove.position.x >= 0.7){
				phase = 3;
				Camera.main.ResetProjectionMatrix();
				Transform cam = Camera.main.GetComponent<Transform>();
				cam.position = new Vector3(-4f,2.3f,-0.5f);
				cam.transform.rotation = Quaternion.Euler(10f,70f,0);
			}
		}
		else if (phase == 3){
			if (elapsedTime >= 11){
				phase = 4;
			}	
		}
		else if (phase == 4){
			mamove.position += new Vector3(-0.9f * Time.deltaTime,0f,-1.1f * Time.deltaTime);
			float rate = -90.0f * 0.01f;
			mamove.Rotate(Vector3.forward,rate);
			mamove.Rotate(Vector3.right,rate*0.3f);
			if(mamove.position.x <= -0.7){
				phase = 5;
			}
		}
		else if (phase == 5){
			mamove.position += new Vector3(2.4f * Time.deltaTime,0f,0f);
			if(mamove.position.x >= 0.7){
				phase = 6;
			}
			
		}
		else if (phase == 6){
			if (elapsedTime >= 15){
				phase = 7;
				Transform cam = Camera.main.GetComponent<Transform>();
				cam.position = new Vector3(0,7,-1);
				cam.transform.rotation = Quaternion.Euler(90,180,0);
			}
		}
		else if (phase == 7){
			
			rojomove.position += new Vector3(0f,-1.5f * Time.deltaTime,-1.5f * Time.deltaTime);
			float rate = -90.0f * 1.5f* Time.deltaTime;
			rojomove.Rotate(Vector3.right,rate);
			if(rojomove.position.y <= 0.4f){
				phase = 8;
			}
			
		}else if (phase == 8){
			crmove.position += new Vector3(0f,0f,-0.08f *Time.deltaTime*(22-elapsedTime));
			float rate = -90.0f * 0.015f;
			crmove.Rotate(Vector3.right,rate);
			if (elapsedTime > 22){
				phase = 9;
			}
		}else if (phase == 9){
			smove.position = new  Vector3(0, 0f, -2f);
			smove.localScale += new Vector3 (-0.3f * Time.deltaTime,0f,-0.3f * Time.deltaTime);
			if (smove.localScale.x >= 8){
				phase = 10;
			}
		}
		
	}
}
