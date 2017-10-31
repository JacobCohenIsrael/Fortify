using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public static int Score;        // The player's score.


	Text text;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		Score = 0;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + Score;
	}
}