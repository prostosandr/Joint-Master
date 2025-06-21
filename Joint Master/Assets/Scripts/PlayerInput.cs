using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    const string QKey = "q";
    const string WKey = "w";
    const string EKey = "e";

    public event Action QPressed;
    public event Action WPressed;
    public event Action EPressed;

    private void Update()
    {
        if (Input.GetKeyDown(QKey))
            QPressed?.Invoke();

        if (Input.GetKeyDown(WKey))
            WPressed?.Invoke();

        if (Input.GetKeyDown(EKey))
            EPressed?.Invoke();
    }
}