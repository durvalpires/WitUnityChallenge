using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICustomizationSection : View {

    public override void hide(bool animate, float delay)
    {
        _dispatchHideCompleted();
    }
}
