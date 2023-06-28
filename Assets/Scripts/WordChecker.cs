using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Checking if the correct word is inside the singleInputList
/// </summary>
public class WordChecker : MonoBehaviour
{
    public string correctWord;
    public SingleInputList singleInputList;

    public ReactiveProperty<char[]> currentString;

    private void Start()
    {
        int wordLength = correctWord.Length;
        currentString = new ReactiveProperty<char[]>(new char[wordLength]);

        for (int i = 0; i < singleInputList.inputFields.Count; i++)
        {
            var i1 = i;
            singleInputList.inputFields[i].onValueChanged.AddListener(input =>
            {
                ChangeCurrentText(input, i1);
            });
        }

        currentString.Subscribe(currentString =>
        {
            // when current string changes, check if it corresponds to the correctWord and change the color
            // also make the other input fields non-interactable
            if (new string(currentString) == correctWord)
            {
                foreach (var singleInput in singleInputList.inputFields)
                {
                    ColorBlock cb = singleInput.colors;
                    cb.disabledColor = Color.green;
                    singleInput.colors = cb;
                    singleInput.interactable = false;
                }
            }
            else
            {
                foreach (var singleInput in singleInputList.inputFields)
                {
                    ColorBlock cb = singleInput.colors;
                    cb.normalColor = Color.white;
                    singleInput.colors = cb;
                }
            }
        });
    }

    private void ChangeCurrentText(string input, int index)
    {
        if (input.Length != 0)
        {
            char[] newCharArray = new char[currentString.Value.Length];
            currentString.Value.CopyTo(newCharArray, 0);
            newCharArray[index] = input[0];
            currentString.Value = newCharArray;
        }
        else
        {
            if (currentString.Value.Length > 0)
            {
                char[] newCharArray = new char[currentString.Value.Length];
                Array.Copy(currentString.Value, newCharArray, currentString.Value.Length);
                newCharArray[newCharArray.Length - 1] = '\0';
                currentString.Value = newCharArray;
            }
        }
    }
}
