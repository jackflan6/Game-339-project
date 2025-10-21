using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(SelectableCard))]
public class CardDropDown : Editor
{
    int _choiceIndex = 0;
    Lazy<string[]> _choices = new Lazy<string[]>(() => {
        IEnumerable<Type> c = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Card)));
        string[] ret = new string[c.Count()];
        int i = 0;
        foreach (Type t in c)
        {
            ret[i] = ((int)t.GetField("cardID").GetValue(null) + ": " + t.Name);
            ++i;
        }
        return ret;
    }
    );


    public override void OnInspectorGUI()
    {
        int i = 0;
        foreach (string choice in _choices.Value)
        {
            if (((SelectableCard)target).cardID == (int)Char.GetNumericValue(choice[0]))
            {
                _choiceIndex = i;
            }
            i++;
        }
        _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.Value);
        var someClass = target as SelectableCard;
        int cardID = (int)Char.GetNumericValue(_choices.Value[_choiceIndex][0]);
        someClass.cardID = cardID;
        //if (someClass.cardID != cardID)
        //{
        //    serializedObject.FindProperty("cardID").intValue = cardID;
        //    serializedObject.ApplyModifiedProperties();
        //}
        // Draw the default inspector
        DrawDefaultInspector();
    }
}
