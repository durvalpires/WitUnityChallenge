using UnityEngine;

public class ControllerSections : MonoBehaviour
{
    #region Change section
    protected GameObject _currentSection;
    protected GameObject _nextSection;

    protected virtual void _switchSection(GameObject section)
    {
        this._nextSection = section;

        if(this._currentSection == null) this._createNextSection();
        else
        {
            if(this._currentSectionView == null)
            {
                Debug.LogWarning("currentSectionView must not be null");
                return;
            }
            //
            this._currentSectionView.onHideCompleted -= this._sectionHideCompleted;
            this._currentSectionView.onHideCompleted += this._sectionHideCompleted;
            this._currentSectionView.hide(true, 0);
        }
    }

    protected void _createNextSection()
    {
        if(!this._nextSection) return;
        //
        this._currentSection = Instantiate(this._nextSection);
        //
        if(this._currentSectionView == null)
        {
            Debug.LogWarning("section must not be null");
            return;
        }
        this.view.section = this._currentSection;
        //
        this._currentSectionView.hide(false, 0);
        this._currentSectionView.onShowCompleted += this._sectionShowCompleted;
        this._currentSectionView.show(true, 0);
        //
        this._nextSection = null;
    }

    protected void _destroyCurrentSection()
    {
        if(!this._currentSection) return;
        //
        if(this._currentSectionView != null)
        {
            this._currentSectionView.onShowCompleted -= this._sectionShowCompleted;
            this._currentSectionView.onHideCompleted -= this._sectionHideCompleted;
            this.view.section = this._currentSection;
        }
        //
        Destroy(this._currentSection);
        this._currentSection = null;
    }

    protected View _currentSectionView
    {
        get
        {
            if(this._currentSection == null) return null;
            return (View)this._currentSection.GetComponent(typeof(View));
        }
    }

    protected virtual void _sectionShowCompleted(object sender, System.EventArgs e)
    {
        // Do something when the section show animation is triggered
    }

    protected virtual void _sectionHideCompleted(object sender, System.EventArgs e)
    {
        this._destroyCurrentSection();
        this._createNextSection();
    }
    #endregion

    #region View
    protected ViewSectionsContainer view
    {
        get { return (ViewSectionsContainer)this.gameObject.GetComponent(typeof(ViewSectionsContainer)); }
    }
    #endregion
}