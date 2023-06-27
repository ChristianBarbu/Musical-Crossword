using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds all input fields (Jump input field scripts).
/// In order to keep track, which array of input fields is currently selected.
/// </summary>
public class InputFieldsManager : MonoBehaviour
{
    public List<JumpInputField> jumpInputFields;

    private void Awake()
    {
        foreach (var jumpInputField in jumpInputFields)
        {
            jumpInputField.singleInputList.inputFields[0].onSelect.AddListener(x =>
            {
                SetActive(jumpInputField);
                jumpInputField.pos = 0;
            });
        }
    }

    public void SetActive(JumpInputField fieldToSetActive)
    {
        fieldToSetActive.fieldActive = true;
        foreach (var otherField in jumpInputFields)
        {
            if (otherField != fieldToSetActive)
                otherField.fieldActive = false;
        }
    }
    
}
