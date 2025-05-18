using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadCreditsLevel()
    {
        // Load the credits level
        UnityEngine.SceneManagement.SceneManager.LoadScene(9);
    }
}
