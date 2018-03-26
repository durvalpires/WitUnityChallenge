using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIVisualizationSection : View {

    public TextMeshProUGUI character1Name;
    public TextMeshProUGUI character2Name;

    private void Awake()
    {
        //GameManagerController.Instance.UpdateCharactersDataFromDisk();
    }

    // Use this for initialization
    void Start () {
        LoadCharacterNames();
	}
	
	public void LoadCharacterNames()
    {
        character1Name.text = GameManagerController.Instance.GetCharacterData(GameManagerController.CHARACTERINDEX.ONE).name;
        character2Name.text = GameManagerController.Instance.GetCharacterData(GameManagerController.CHARACTERINDEX.TWO).name;

        Sequence mySequence = DOTween.Sequence();
        DOTween.Kill("CharNamesVisHide" + this.GetInstanceID());
        mySequence.SetId("CharNamesVisShow" + this.GetInstanceID());
        mySequence.OnComplete(() => { _dispatchShowCompleted(); });
        mySequence.Append(character1Name.DOFade(1f, .3f));
        mySequence.Join(character2Name.DOFade(1f, .3f));
        mySequence.PrependInterval(.05f);
    }

    public override void hide(bool animate, float delay)
    {
        //base.hide(animate, delay);

        Sequence mySequence = DOTween.Sequence();
        DOTween.Kill("CharNamesVisShow" + this.GetInstanceID());
        mySequence.SetId("CharNamesVisHide" + this.GetInstanceID());
        mySequence.OnComplete(() => { _dispatchHideCompleted(); });
        // Add a movement tween at the beginning
        mySequence.Append(character1Name.DOFade(0f, 0f));
        mySequence.Join(character2Name.DOFade(0f, .0f));
    }
}
