using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChangeScenes(int _numder)
    {
        SceneManager.LoadScene(_numder);
    }
}
