using UnityEngine;
using System.Collections;
using System.Text;

public class BallManager : MonoBehaviour
{
    struct LetterFrequency
    {
        public char letter;
        public int weight;

        public LetterFrequency(char _letter, int _weight)
        {
            letter = _letter;
            weight = _weight;
        }
    }

    LetterFrequency[] frequencyTable = new LetterFrequency[]
    {
        new LetterFrequency('A', 82),
        new LetterFrequency('B', 15),
        new LetterFrequency('C', 28),
        new LetterFrequency('D', 42),
        new LetterFrequency('E', 127),
        new LetterFrequency('F', 22),
        new LetterFrequency('G', 20),
        new LetterFrequency('H', 61),
        new LetterFrequency('I', 70),
        new LetterFrequency('J', 2),
        new LetterFrequency('K', 8),
        new LetterFrequency('L', 40),
        new LetterFrequency('M', 24),
        new LetterFrequency('N', 67),
        new LetterFrequency('O', 75),
        new LetterFrequency('P', 19),
        new LetterFrequency('Q', 1),
        new LetterFrequency('R', 60),
        new LetterFrequency('S', 63),
        new LetterFrequency('T', 91),
        new LetterFrequency('U', 28),
        new LetterFrequency('V', 10),
        new LetterFrequency('W', 24),
        new LetterFrequency('X', 2),
        new LetterFrequency('Y', 20),
        new LetterFrequency('Z', 1),
    };


    public GameObject ballPrefab;

    StringBuilder letterPool;

	void Start()
    {
        float startX = -4f;
        float startY = -4f;
        float spacing = 1f;

        letterPool = new StringBuilder();

        for (int i = 0; i < frequencyTable.Length; ++i)
        {
            letterPool.Append(frequencyTable[i].letter, frequencyTable[i].weight);
        }


	    for (int i = 0; i < 10; ++i)
        {
            for (int j = 0; j < 5; ++j)
            {
                var ball = Instantiate<GameObject>(ballPrefab);
                ball.transform.position = new Vector3(startX + spacing * i, startY + spacing * j, 0);
                int index = Random.Range(0, letterPool.Length);
                ball.GetComponent<Ball>().Letter = letterPool.ToString().Substring(index, 1);
            }
        }
	}
}
