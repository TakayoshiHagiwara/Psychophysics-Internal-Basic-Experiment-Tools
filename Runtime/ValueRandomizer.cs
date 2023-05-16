// -----------------------------------------------------------------------
// Author:  Takayoshi Hagiwara (Toyohashi University of Technology)
// Created: 2023/5/14
// Summary: Manager of value randomizer. Rondomize input values.
// -----------------------------------------------------------------------

using System.Text;
using TMPro;
using UnityEngine;

public class ValueRandomizer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputValueText;
    [SerializeField]
    private TextMeshProUGUI resultText;

    private string[] inputValues;
    private string[] shuffledValues;
    private StringBuilder sbResult = new StringBuilder();

    // Start is called before the first frame update
    void Start()
    {
        InitResultText();
    }

    /// <summary>
    /// Randomize input values
    /// </summary>
    private void Randomize()
    {
        inputValues = inputValueText.text.Replace(" ", "").Split(",");
        shuffledValues = Shuffle(inputValues);

        sbResult.Clear();
        foreach (string result in shuffledValues)
        {
            sbResult.Append(result);
            sbResult.Append("\n");
        }
        resultText.text = sbResult.ToString();
    }

    /// <summary>
    /// Shuffle array
    /// </summary>
    /// <param name="array">target array</param>
    /// <returns>shuffled array</returns>
    private string[] Shuffle(string[] array)
    {
        for(int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            string tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        return array;
    }

    /// <summary>
    /// Initialize result text
    /// </summary>
    public void InitResultText()
    {
        resultText.fontSize = 14;
        resultText.text = "Enter values separated by commas and press the Randomize button";
    }

    /// <summary>
    /// Click button
    /// </summary>
    public void OnClick()
    {
        resultText.fontSize = 24;
        Randomize();
    }
}
