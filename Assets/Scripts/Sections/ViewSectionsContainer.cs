﻿using UnityEngine;

public class ViewSectionsContainer : View
{
    #region Section
    protected GameObject _section;

    public GameObject section
    {
        get { return this._section; }

        set
        {
            this._section = value;
            if(this._section == null) return;
            this._section.transform.SetParent(this.transform, false);
        }
    }
    #endregion
}