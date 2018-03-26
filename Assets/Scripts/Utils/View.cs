using System;
using UnityEngine;


public class View : MonoBehaviour
{
    #region Show / Hide
    public event EventHandler<EventArgs> onShowCompleted;
    public event EventHandler<EventArgs> onHideCompleted;
    [HideInInspector]
    public bool shown;

    public void show() { show(true, 0); }

    public void show(bool animate) { show(animate, 0); }

    public void show(float delay) { show(true, delay); }

    public virtual void show(bool animate, float delay) { this.shown = true; }

    public void hide() { hide(true, 0); }

    public void hide(bool animate) { hide(animate, 0); }

    public void hide(float delay) { hide(true, delay); }

    public virtual void hide(bool animate, float delay) { this.shown = false; }

    protected virtual void _dispatchShowCompleted()
    {
        if (this.onShowCompleted != null) this.onShowCompleted(this, new EventArgs());
    }

    protected virtual void _dispatchHideCompleted()
    {
        if (this.onHideCompleted != null) this.onHideCompleted(this, new EventArgs());
    }
    #endregion

}
