using UnityEngine;
using System.Collections;
using UnityEngine.UI;
    
public class DialogBoxManager : MonoBehaviour {

    public GameObject textBoxTemplate;
    public Text dialogText;

    public TextAsset textFile;
    private string[] textLines;

    private int currentLine;
    private int endOfLine = 0;

    // Use this for initialization
    void Start() {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endOfLine == 0)
        {
            endOfLine = textLines.Length - 1;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(!textBoxTemplate.active)
        {
            return;
        }

        dialogText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.T))
        {
            currentLine += 1;
        }

        if(currentLine > endOfLine)
        {
            textBoxTemplate.SetActive(false);
        }
	}
}
