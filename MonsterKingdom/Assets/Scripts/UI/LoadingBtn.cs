using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBtn : MonoBehaviour
{
    private Button _loadingButton;
    void Start()
    {
        _loadingButton = GetComponent<Button>();
        // SceneManager.LoadSceneAsync("BattleScene");
        if (_loadingButton!=null)
        {
            _loadingButton.onClick.RemoveAllListeners();
            _loadingButton.onClick.AddListener(() =>
            {
                /*SceneManager.LoadSceneAsync("BattleScene")!.completed += operation =>
                {
                    if (operation.isDone)
                    {
                        
                        UIManager.instance.ShowPanel("CardSettingPanel");
                    }
                };*/
                //_loadingButton.gameObject.SetActive(false);
                UIManager.instance.ShowPanel("CardSettingPanel");
            });
        }
        else
        {
            Debug.LogError("LoadingButton is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
