using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonLevel : MonoBehaviour {

	[SerializeField] string levelName;

	public void LoadLevel() {
		SceneManager.LoadScene(levelName);
	}
	
}
