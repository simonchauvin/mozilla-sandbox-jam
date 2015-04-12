using UnityEngine;
using System.Collections;

public class DecalMovement : MonoBehaviour {

	public float maxSpeed = 0.05f;
	public float minSpeed = 0.05f;

	private Vector2 _offsetVector;
	private Renderer _renderer;
	private Vector2 _lastOffset;

	// Use this for initialization
	void Start () {

		_offsetVector = new Vector2(Random.Range(-maxSpeed, maxSpeed), Random.Range(-maxSpeed, maxSpeed));
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		_lastOffset = _renderer.material.GetTextureOffset("_MainTex") + _offsetVector * Time.deltaTime;
		_renderer.material.SetTextureOffset("_MainTex", _lastOffset);
	}
}
