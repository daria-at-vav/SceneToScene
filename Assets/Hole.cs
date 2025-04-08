using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : NonPlayerObject
{
    [SerializeField] Transform playerTransform;
    [SerializeField] string nextSceneName;

    private SceneManager sceneChanger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - playerTransform.position).sqrMagnitude < Mathf.Epsilon){
                SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
    }
}
