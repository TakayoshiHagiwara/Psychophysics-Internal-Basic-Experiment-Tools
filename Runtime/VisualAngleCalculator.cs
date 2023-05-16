// -----------------------------------------------------------------------
// Author:  Takayoshi Hagiwara (Toyohashi University of Technology)
// Created: 2023/5/14
// Summary: Manager of visual angle calculator.
// -----------------------------------------------------------------------

using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualAngleCalculator : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputFieldDistance;
    private string _strInputDistance;
    private float _inputDistance;
    [SerializeField]
    private TMP_InputField _inputFieldTargetSize;
    private string _strInputTargetSize;
    private float _inputTargetSize;
    [SerializeField]
    private ToggleGroup _toggleGroup;
    [SerializeField]
    private TextMeshProUGUI _resultText;

    private Toggle _activeToggle;

    private const float ONE_PIXEL = 0.0003f; // 1 pixel ÅÅ 0.0003 [m]
    private float _pixelM;
    private float _visualAngleRad;
    private float _visualAngleDeg;

    // Start is called before the first frame update
    void Start()
    {
        InitInputField();
    }

    /// <summary>
    /// Calculate visual angle from distance and target size
    /// </summary>
    private void Calculate()
    {
        _strInputDistance = _inputFieldDistance.text;
        _strInputTargetSize = _inputFieldTargetSize.text;
        if (string.IsNullOrEmpty(_strInputDistance) || string.IsNullOrEmpty(_strInputTargetSize))
        {
            _resultText.text = "No value input";
            return;
        }

        if (!(float.TryParse(_strInputDistance, out _inputDistance)) || !(float.TryParse(_strInputTargetSize, out _inputTargetSize)))
        {
            _resultText.text = "Input is NOT numeric";
            return;
        }

        _activeToggle = _toggleGroup.ActiveToggles().FirstOrDefault();
        switch (_activeToggle.name)
        {
            //Calculate visual angle
            case "ToggleTargetPixel":
                _pixelM = _inputTargetSize * ONE_PIXEL;

                _visualAngleRad = 2 * Mathf.Atan(_pixelM / (2 * _inputDistance));
                _visualAngleDeg = (_visualAngleRad * 180) / Mathf.PI;
                Debug.Log("VISUAL ANGLE [deg] : " + _visualAngleDeg);
                Debug.Log("VISUAL ANGLE [min] : " + _visualAngleDeg * 60);

                _resultText.text = "VISUAL ANGLE [deg] : " + _visualAngleDeg +
                                   "\nVISUAL ANGLE [min] : " + (_visualAngleDeg * 60);
                break;

            case "ToggleTargetMeter":
                _visualAngleRad = 2 * Mathf.Atan(_inputTargetSize / (2 * _inputDistance));
                _visualAngleDeg = (_visualAngleRad * 180) / Mathf.PI;
                Debug.Log("VISUAL ANGLE [deg] : " + _visualAngleDeg);
                Debug.Log("VISUAL ANGLE [min] : " + _visualAngleDeg * 60);

                _resultText.text = "VISUAL ANGLE [deg] : " + _visualAngleDeg +
                                "\nVISUAL ANGLE [min] : " + (_visualAngleDeg * 60);
                break;
        }
    }

    /// <summary>
    /// Initialize input field
    /// </summary>
    public void InitInputField()
    {
        _resultText.text = "1 : Select the unit of target size\n2 : Enter observation distance and object size";
        _inputFieldDistance.text = "";
        _inputFieldTargetSize.text = "";
    }

    /// <summary>
    /// Click button
    /// </summary>
    public void OnClick()
    {
        Calculate();
    }
}
