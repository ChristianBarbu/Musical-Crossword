using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldGridGenerator : MonoBehaviour
{
    public TMP_InputField singleInputFieldPrefab;

    public Vector3 startPosition;

    public GameObject background;
    
    public int width;
    public int height;

    public string wordToEnter;
    
    public bool horizontal;

    public InputFieldsManager fieldsManager;
    
    public void GenerateGrid()
    {
        var bigInputField = new GameObject(wordToEnter);
        var jumpInputField = bigInputField.AddComponent<JumpInputField>();
        var wordChecker = bigInputField.AddComponent<WordChecker>();
        var singleInputList = bigInputField.AddComponent<SingleInputList>();
        bigInputField.AddComponent<SharedInputFields>();

        List<TMP_InputField> inputFieldList = new List<TMP_InputField>();
        
        wordChecker.singleInputList = singleInputList;
        jumpInputField.singleInputList = singleInputList;

        fieldsManager.jumpInputFields.Add(jumpInputField);
        
        wordChecker.correctWord = RemoveEmptySpaces(wordToEnter);

        for (int i = 0; i < wordToEnter.Length; i++)
        {
            var vectorDisplacement = new Vector3();
            if (horizontal)
            {
                vectorDisplacement = new Vector3(i * 30, 0, 0);   
            }
            else
            {
                vectorDisplacement = new Vector3(0, -i * 30, 0);   
            }

            var inputField = Instantiate(singleInputFieldPrefab);
            inputField.GetComponent<RectTransform>().position =
                new Vector3(startPosition.x + vectorDisplacement.x, startPosition.y + vectorDisplacement.y, 0);
            inputField.transform.SetParent(bigInputField.transform);
                
            inputFieldList.Add(inputField);
                
            bigInputField.transform.SetParent(background.transform);
        }
        

        var whiteSpaceIndices = FindSpaceIndices();
        int j = 0;
            for (int i = 0; i < inputFieldList.Count; i++)
            {
                if (j < whiteSpaceIndices.Length && i == whiteSpaceIndices[j])
                {   
                    inputFieldList[i].interactable = false;
                    j++;
                }
            }

            singleInputList.inputFields = new List<TMP_InputField>();
            
            for (int i = 0; i < inputFieldList.Count; i++)
            {
                if(inputFieldList[i].interactable)
                    singleInputList.inputFields.Add(inputFieldList[i]);
            }

    }

    private int[] FindSpaceIndices()
    {
        // Create a list to store the indices of empty spaces
        List<int> indices = new List<int>();
        
        for (int i = 0; i < wordToEnter.Length; i++)
        {
            if (wordToEnter[i] == ' ')
            {
                indices.Add(i);
            }
        }
        
        // Convert the list to an array and return
        return indices.ToArray();
    }
    
    public string RemoveEmptySpaces(string input)
    {
        // Use the Replace method to remove all empty spaces
        string result = input.Replace(" ", string.Empty);
        
        return result;
    }
    
}

[CustomEditor(typeof(InputFieldGridGenerator))]
public class InputFieldGridGeneratorEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InputFieldGridGenerator generator = (InputFieldGridGenerator) target;
        if (GUILayout.Button("Generate Grid"))
        {
            generator.GenerateGrid();
        }

    }
}
