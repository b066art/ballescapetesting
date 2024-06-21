using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("level_00");
    }
}