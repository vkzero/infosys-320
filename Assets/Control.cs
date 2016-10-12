using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {
    public string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoNothing() {
        return;
    }

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    void OnMouseDown() {
        LoadScene(scene);
    }

    void OnCollisionEnter(Collision col) {
        LoadScene(scene);
    }
}
