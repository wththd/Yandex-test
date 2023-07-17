using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour
{
    public event Action PlayClicked;

    public void OnPlayClick()
    {
        PlayClicked?.Invoke();
    }
}
