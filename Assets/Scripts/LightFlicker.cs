using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float flickerLowTargert = 1.0f;
	public float flickerHightTarget = 7.99f;

	private float flickerCurrentTarget = 0.0f;
	private float flickerMinTarget = 1.0f;
	private float flickerMaxTarget = 7.99f;

	private float defaultLowTarget = 3.0f;
	private float defaultHighTarget = 7.0f;

	private Light fLight;

	public float speed = 1.0f;
	private float step = 0.0f;

	void Start(){
		fLight = gameObject.GetComponent<Light> ();
		flickerCurrentTarget = flickerHightTarget;
		fLight.intensity = flickerLowTargert;
	}
	
	// Update is called once per frame
	void Update () {
		if (flickerLowTargert >= flickerHightTarget)
			flickerLowTargert = defaultLowTarget;
		if (flickerHightTarget <= flickerLowTargert)
			flickerHightTarget = defaultHighTarget;
		if (flickerLowTargert < flickerMinTarget)
			flickerLowTargert = flickerMinTarget;
		if (flickerHightTarget > flickerMaxTarget)
			flickerHightTarget = flickerMaxTarget;

		if (fLight.intensity <= flickerCurrentTarget) {
			flickerCurrentTarget = flickerHightTarget;
			step = speed * Time.deltaTime;
			fLight.intensity += step;
		} else if(fLight.intensity >= flickerCurrentTarget){
			flickerCurrentTarget = flickerLowTargert;
			step = speed * Time.deltaTime;
			fLight.intensity -= step;
		}
	}
}
