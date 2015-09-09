using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TapSpaceBar : MonoBehaviour {
	public float timeBeforeInput = 3.5f;        // The time is seconds before the player can input

	Animator anim;								// Reference to the animator component.
	float timer;                                // Timer for counting up to let player input

	void Start()
	{
		// Set up the reference.
		anim = GetComponent<Animator> ();

		//set up timer.
		timer = 0f;
	}

	void Update()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;

		//if the player press any key
		if(timer >= timeBeforeInput && Input.anyKeyDown && !Input.GetButton ("Fire1"))
		{
			//if the player press space key or tap/click the space button in Main screen
			if(Input.GetKeyDown(KeyCode.Space))
			{
				//tell the animator player wins the game
				anim.SetTrigger("Win");
			}
			//otherwise the player loses
			else
			{
				anim.SetTrigger("Lose");
			}
		}
	}

	public void SpaceButtonClick()
	{
		if (timer >= timeBeforeInput) {
			//if player uses mouse to click or use finger to touch, still a win
			anim.SetTrigger ("Win");
		}
	}

	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
