using UnityEngine;
using System.Collections;
 
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class cameraOrbit : MonoBehaviour {
 
   public bool orbitDisabled = false;

    public float distance = 10f;
    public float xSpeed = 80.0f;
    public float ySpeed = 80.0f;
 
    public float yMinLimit = 10f;
    public float yMaxLimit = 80f;
 
    public float distanceMin = .5f;
    public float distanceMax = 15f;

	private Transform target;
	private GameObject player;
    private Rigidbody rigidbody;
	private Rigidbody playerRigidbody;
 
    float x = 0.0f;
    float y = 0.0f;
	void Start(){
		Invoke("Init",0.1f);
	}
    // Use this for initialization
    void Init () 
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
 
        rigidbody = GetComponent<Rigidbody>();
 
        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
		player = GameObject.FindGameObjectWithTag("Player");
		playerRigidbody = player.GetComponent<Rigidbody>();
		if(target == null){
			target = player.transform;
		}

    }
 
    void LateUpdate () 
    {
        if (target && Time.timeScale > 0) 
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
 
            y = ClampAngle(y, yMinLimit, yMaxLimit);
 			
            Quaternion rotation = Quaternion.Euler(y, x, 0);
 
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*5, distanceMin, distanceMax);
 
//            RaycastHit hit;
//            if (Physics.Linecast (target.position, transform.position, out hit)) 
//            {
//                distance -=  hit.distance;
//            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
			if(!orbitDisabled){
            	transform.rotation = rotation;
            	transform.position = position;
			}else{
				transform.position = position+negDistance;
			}
		}
    }
 
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
