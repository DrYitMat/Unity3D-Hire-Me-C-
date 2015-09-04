using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float flickerLowTarget = 1.0f;
	public float flickerHightTarget = 7.99f;

	private float flickerCurrentTarget = 0.0f;
	private float flickerMinTarget = 1.0f;
	private float flickerMaxTarget = 7.99f;

	private float defaultLowTarget = 3.0f;
	private float defaultHighTarget = 7.0f;

	private Light fLight;

	public float speed = 1.0f;
	private float step = 0.0f;

	private	Color targetColor;
	private Color baseColor;
	private Color pickedColor;

	public bool strobeLightMode = false;

	public float colorChangeSpeed = 0.01f;

	private float colorThreshold;

	private float colorChangeSpeedMin = .001f;
	private float colorChangeSpeedDefault = .01f;
	private float colorChangeSpeedMax = .05f;

	void Start(){
		fLight = gameObject.GetComponent<Light> ();
		flickerCurrentTarget = flickerHightTarget;
		fLight.intensity = flickerLowTarget;
		baseColor = fLight.color;
		Debug.Log("Picking base Color");
		float r = Random.Range(.01f, 1f);
		float g = Random.Range(.01f, 1f);
		float b = Random.Range(.01f, 1f);
		pickedColor = new Color(r,g,b);
		Debug.Log(pickedColor);
		colorThreshold = 0.01f;
	}

	private void ChangeColor(){
		float a = Mathf.Abs ((fLight.color.r - pickedColor.r) + (fLight.color.g - pickedColor.g) + (fLight.color.b - pickedColor.b));
		if(a <= colorThreshold){
			float r = Random.Range(.01f, 1f);
			float g = Random.Range(.01f, 1f);
			float b = Random.Range(.01f, 1f);
			pickedColor = new Color(r,g,b);
		}
		else {
			if(fLight.color.r > pickedColor.r) baseColor.r -= colorChangeSpeed;
			if(fLight.color.r < pickedColor.r) baseColor.r += colorChangeSpeed;
			
			if(fLight.color.g > pickedColor.g) baseColor.g -= colorChangeSpeed;
			if(fLight.color.g < pickedColor.g) baseColor.g += colorChangeSpeed;
			
			if(fLight.color.b > pickedColor.b) baseColor.b -= colorChangeSpeed;
			if(fLight.color.b < pickedColor.b) baseColor.b += colorChangeSpeed;
			
			fLight.color = baseColor;
		}
	}

	// Update is called once per frame
	void Update () {
		if (flickerLowTarget >= flickerHightTarget)
			flickerLowTarget = defaultLowTarget;
		if (flickerHightTarget <= flickerLowTarget)
			flickerHightTarget = defaultHighTarget;
		if (flickerLowTarget < flickerMinTarget)
			flickerLowTarget = flickerMinTarget;
		if (flickerHightTarget > flickerMaxTarget)
			flickerHightTarget = flickerMaxTarget;

		if (fLight.intensity <= flickerCurrentTarget) {
			flickerCurrentTarget = flickerHightTarget;
			step = speed * Time.deltaTime;
			fLight.intensity += step;
		} else if(fLight.intensity >= flickerCurrentTarget){
			flickerCurrentTarget = flickerLowTarget;
			step = speed * Time.deltaTime;
			fLight.intensity -= step;
		}

		if (colorChangeSpeed >= colorChangeSpeedMax)
			colorChangeSpeed = colorChangeSpeedDefault;
		else if (colorThreshold <= colorChangeSpeedMin)
			colorChangeSpeed = colorChangeSpeedDefault;

		colorThreshold = colorChangeSpeed;

		if (strobeLightMode) {
			ChangeColor ();
		}
	}
}
