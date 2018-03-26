﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

    public LayerMask lMask;

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0 && Input.touchCount < 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    checkTouch(Input.GetTouch(0).position);
                }
            }
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                checkTouch(Input.mousePosition);
            }
        }

    }

    private void checkTouch(Vector3 pos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pos);

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Physics.Raycast(ray, out hit, 50f, lMask))
        {
            SoundManager.Instance.PlaySfx(SoundManager.SFX.POSITIVE);
            GameManagerController.Instance.SetSelectedCharacter(hit.transform.GetComponent<Character>().index);
            ServiceSections.Instance.selected = ServiceSections.SECTION.CUSTOMIZATION;
            SceneManager.LoadSceneAsync(2);
        }
    }
}
