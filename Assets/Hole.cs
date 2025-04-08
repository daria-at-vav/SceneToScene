using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : NonPlayerObject
{

    [SerializeField] string nextSceneName;

    public override void Interact()
    {
        SceneManager.LoadScene(nextSceneName);
    }


}
