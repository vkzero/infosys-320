using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Search : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void search(Text input) {
        switch (input.text) {
            case "toilet":
                SceneManager.LoadScene("Toilet");
                break;
            case "traffic":
                SceneManager.LoadScene("Traffic");
                break;
            case "volcano":
                SceneManager.LoadScene("Volcano");
                break;
            default:
                SceneManager.LoadScene("Search");
                break;
        }
    }

    public void Back() {
        SceneManager.LoadScene("Museum");
    }
}
