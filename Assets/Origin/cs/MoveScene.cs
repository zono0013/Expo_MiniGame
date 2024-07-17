using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MoveScene : MonoBehaviour
{
    private readonly Dictionary<string, string> tagToSceneMap = new Dictionary<string, string>
    {
        { "Quiz", "QuizScene" },
        { "Darts", "DartsScene" },
        { "Bowling", "bowling" }
    };

    public void OnButtonClick()
    {
        MoveToScene();
    }

    private void MoveToScene()
    {
        string tag = gameObject.tag;
        if (tagToSceneMap.TryGetValue(tag, out string sceneName))
        {
            try
            {
                SceneManager.LoadScene(sceneName);
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Failed to load scene: {sceneName}. Error: {e.Message}");
            }
        }
        else
        {
            Debug.LogWarning($"No scene mapping found for tag: {tag}");
        }
    }
}
