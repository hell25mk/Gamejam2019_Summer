using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eSceneList : int
{
    Scene_Title = 0,
    Scene_Game,
    Scene_Result,
}

public class SceneMoveManager : MonoBehaviour
{

    [SerializeField]
    private eSceneList moveScene;

    public void LoadScene()
    {
        SceneManager.LoadScene((int)moveScene);
    }

    public void SetMoveScene(eSceneList scene)
    {
        moveScene = scene;
    }

    public void ToGameEnd()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }

}
