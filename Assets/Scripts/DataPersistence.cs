using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataPersistence : MonoBehaviour {
	
	public static DataPersistence Instance;
	public Dictionary<string, bool> achievements; // fica com int pq pode ser preciso para mais cenas
	
	void Awake () {
		Instance = this;
		DontDestroyOnLoad(this);
		achievements = new Dictionary<string, bool>();
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
