using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GDClone.Canvas
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGameBtn(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
