using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Wrap : MonoBehaviour {

    SceneTransformation sceneFadeManager;
    public int levelChangeDirection = 1;//1 - next level, -1 - previous level

	// Use this for initialization
	void Start () {
        sceneFadeManager = GameObject.Find("SceneFadeManager").GetComponent<SceneTransformation>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collide With: " + other.gameObject.name);
        //Begin level Changing
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        //Start with fade
        float fadeTime = sceneFadeManager.BeginFade(1);
        //Wait fade time
        yield return new WaitForSeconds(fadeTime);
        //Change level
        for (int i = 0; i < SceneManager.GetAllScenes().Length; i++)
        {
            if(SceneManager.GetActiveScene().name == SceneManager.GetSceneAt(i).name)
            {
                Debug.Log("Active Scene Index: " + i);
                SceneManager.LoadScene(i+1);

                break;
            }
        }
    }
}
