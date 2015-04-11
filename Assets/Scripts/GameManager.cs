using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// The instance of the GameManager.
    /// </summary>
    private static GameManager _instance;

    // COLORS
    public Color red;
    public Color green;
    public Color blue;


    /// <summary>
    /// Retrieve the instance of the game manager.
    /// </summary>
    /// <value>The game manager.</value>
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            return _instance;
        }
    }


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
