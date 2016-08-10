using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public TextAsset wordList;
    string[] words;

	void Start()
    {
        words = wordList.text.Split(System.Environment.NewLine.ToCharArray());
	}
	
    public bool Validate(string word)
    {
        int index = System.Array.BinarySearch<string>(words, word);
        return index >= 0;
    }
}
