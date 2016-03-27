//Created by: Fabian Verkuijlen

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    protected void Awake()
    {
        Invoke("TransitionToMain", 4f);
    }
    private void TransitionToMain()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
