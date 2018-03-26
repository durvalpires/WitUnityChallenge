using System;
using UnityEngine;

public class ServiceSections {

    #region Selected Section
    public delegate void SelectedChangeDelegate(SECTION selected);
    public event SelectedChangeDelegate onSelectedChanged;

    public enum SECTION
    {
        INTRO,
        VISUALIZATION,
        CUSTOMIZATION
    }

    protected SECTION _selected;

    public SECTION selected
    {
        get { return this._selected; }
        set
        {
            //if (value == this._selected) return;
            this._previouslySelected = this._selected;
            this._selected = value;
            if (this.onSelectedChanged != null) this.onSelectedChanged(this._selected);
        }
    }

    protected SECTION _previouslySelected;

    public SECTION previouslySelected
    {
        get { return this._previouslySelected; }
        protected set
        {
            if (value == this._previouslySelected) return;
            this._selected = value;
        }
    }
    #endregion

    #region Singleton
    private static ServiceSections instance;

    private ServiceSections() { }

    public static ServiceSections Instance
    {
        get
        {
            if (instance == null) instance = new ServiceSections();
            return instance;
        }
    }
    #endregion

}
