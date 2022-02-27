using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReScenes : MonoBehaviour
{
    // Start is called before the first frame update
  public void MenuOn()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOn()
    {
        SceneManager.LoadScene(1);
    }
}
