using UnityEngine;
using System.Collections;
/// <summary>
/// Cast and Receive shadows.
/// 
/// NOTE: The material created does not allow for the sprite to be flipped by rotation or scale.
/// 
/// </summary>
/// You'll need to make a new animation with everything flipped in order to do so.
public class RecieveShadows : MonoBehaviour {

	public bool castShadows = true;

	public bool recieveShadows= true;

	// Use this for initialization
	void Start () {
		if (castShadows) {
			GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
		GetComponent<Renderer> ().receiveShadows = recieveShadows;
	}

	void Update(){
		if (castShadows) {
			GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
		}
		GetComponent<Renderer> ().receiveShadows = recieveShadows;
	}
}
