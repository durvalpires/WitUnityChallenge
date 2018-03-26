using System;
using UnityEngine;

[RequireComponent(typeof(ViewSectionsContainer))]
public class ControllerMainSections : ControllerSections
{
    #region Lifecycle
    protected void Awake()
    {
        ServiceSections.Instance.onSelectedChanged += this._sectionChanged;
    }

    protected void OnDestroy()
    {
        ServiceSections.Instance.onSelectedChanged -= this._sectionChanged;
    }
    #endregion

    #region Sections Prefabs
    public GameObject introPrefab;
    public GameObject visualizationPrefab;
    public GameObject customizationPrefab;
    #endregion

    #region Change section
    private void _sectionChanged(ServiceSections.SECTION selected)
    {
        switch(selected)
        {
            case ServiceSections.SECTION.INTRO:
                this._switchSection(introPrefab);
                break;
            case ServiceSections.SECTION.VISUALIZATION:
                this._switchSection(visualizationPrefab);
                break;
            case ServiceSections.SECTION.CUSTOMIZATION:
                this._switchSection(customizationPrefab);
                break;
            default:
                this._switchSection(null);
                break;
        }
    }
    #endregion
}