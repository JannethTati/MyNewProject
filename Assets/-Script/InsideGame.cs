using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideGame : MonoBehaviour
{
    #region Unity Callbacks

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }

    #endregion
}
