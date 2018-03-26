using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIIntroSection : View {

    public Image background;

	void Start () {
        GameManagerController.Instance.UpdateCharactersDataFromDisk();
        background.DOFade(1f, .5f);
        Invoke("LoadVisualization", 2f);
	}

    #region Visualization Section Loading
    protected void LoadVisualization()
    {
        background.DOFade(0f, 3f);
        ServiceSections.Instance.selected = ServiceSections.SECTION.VISUALIZATION;

        SceneManager.sceneLoaded += OnVisualizationFinishedLoading;
        SceneManager.LoadSceneAsync(1);
    }

    private void OnVisualizationFinishedLoading(Scene arg0, LoadSceneMode arg1)
    {
        SceneManager.sceneLoaded -= OnVisualizationFinishedLoading;

    }
    #endregion

    #region Hide
    public override void hide(bool animate, float delay)
    {
        //base.hide(animate, delay);

        background.DOFade(0f, 0f).OnComplete(() => { _dispatchHideCompleted(); });
    }
    #endregion
}
