using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour {

    public bool ReadReload()
    {
        return Input.GetKeyDown(KeyCode.R);
    }

    private void Update ()
    {
        if(ReadReload())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		
	}
}
