using UnityEngine;

public class LookAtPlanet : MonoBehaviour {

	public Camera cam;
	Quaternion localRotation;
	public Transform[] planet;
	Transform planetTarget = null;
	
	// Use this for initialization
	void Start ()
	{
		localRotation = cam.transform.localRotation;
	}

	// Update is called once per frame
	void Update()
	{
		if (planetTarget != null)
		{
			cam.transform.LookAt(planetTarget);
		}
	}

	public void Default()
	{
		cam.orthographicSize = 120f;
		planetTarget = null;
		cam.transform.rotation = localRotation;
	}

	public void LookAtSun()
	{
		cam.orthographicSize = 28f;
		planetTarget = planet[0];
	}

	public void LookAtMercury()
	{
		cam.orthographicSize = 10f;
		planetTarget = planet[1];
	}

	public void LookAtVenus()
	{
		cam.orthographicSize = 12f;
		planetTarget = planet[2];
	}

	public void LookAtEarth()
	{
		cam.orthographicSize = 10f;
		planetTarget = planet[3];
	}

	public void LookAtMars()
	{
		cam.orthographicSize = 15f;
		planetTarget = planet[4];
	}

	public void LookAtJupiter()
	{
		cam.orthographicSize = 15f;
		planetTarget = planet[5];
	}

	public void LookAtSaturn()
	{
		cam.orthographicSize = 20f;
		planetTarget = planet[6];
	}

	public void LookAtUranus()
	{
		cam.orthographicSize = 15f;
		planetTarget = planet[7];
	}

	public void LookAtNeptune()
	{
		cam.orthographicSize = 15f;
		planetTarget = planet[8];
	}


    public void LookANebula()
    {
        cam.orthographicSize = 20f;
        planetTarget = planet[9];
    }

    public void LookAtMoon()
    {
        cam.orthographicSize = 15f;
        planetTarget = planet[10];
    }

    public void LookAtMeteor()
    {
        cam.orthographicSize = 15f;
        planetTarget = planet[11];
    }

    public void LookAtPluto()
    {
        cam.orthographicSize = 10f;
        planetTarget = planet[12];
    }
}