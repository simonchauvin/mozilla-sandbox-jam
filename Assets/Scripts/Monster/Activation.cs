using UnityEngine;
using System.Collections;

public class Activation : MonoBehaviour
{
    // VARIABLES
    private GameObject activatedObject;
    private MeshRenderer activatedObjectRenderer;
    private Color startingColor;
    private Color targetColor;
    private float fadingTimer;
    private bool canFade;


	// Use this for initialization
	void Start ()
    {
        fadingTimer = 99f;
        canFade = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canFade)
        {
            if (fadingTimer <= 2f)
            {
                activatedObjectRenderer.material.SetColor("_EmissionColor", Color.Lerp(startingColor, targetColor, fadingTimer / 2f));
                fadingTimer += Time.deltaTime;
            }
            else
            {
                fadingTimer = 0f;
                canFade = false;
                activatedObject.SetActive(false);
            }
        }
	}

    void OnTriggerEnter (Collider collider)
    {
        if (collider.CompareTag("Activeable"))
        {
            canFade = true;
            fadingTimer = 0f;
            activatedObject = collider.gameObject;
            activatedObjectRenderer = collider.GetComponent<MeshRenderer>();
            startingColor = activatedObjectRenderer.material.GetColor("_EmissionColor");
            targetColor = collider.GetComponent<Activeable>().targetColor;
        }
    }
}
