using UnityEngine;

public class JumpInputField : MonoBehaviour
{
    public SingleInputList singleInputList;
    public int pos = 0;
    public bool fieldActive = false;
    
    private void Awake()
    {
        foreach (var inputField in singleInputList.inputFields)
        {
            inputField.onValueChanged.AddListener(inputString => { JumpTo(inputString);});
        }
        
    }

    private void JumpTo(string inputString)
    {
        if (inputString.Length == 0)
        {
            if (pos > 0)
                pos--;
        }
        else
        {
            pos++;   
        }

        if (pos < singleInputList.inputFields.Count)
        {
            if (!fieldActive) return;

            if (!singleInputList.inputFields[pos].interactable)
            {
                Debug.Log($"!singleInputList.inputFields[pos].interactable");
                pos++;
            }
            
            singleInputList.inputFields[pos].Select();
            if (singleInputList.inputFields[pos].text != "")
                singleInputList.inputFields[pos].text = "";
        }
    }
    
}
