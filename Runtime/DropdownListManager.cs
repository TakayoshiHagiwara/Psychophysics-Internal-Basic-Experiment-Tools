// -----------------------------------------------------------------------
// Author:  Takayoshi Hagiwara (Toyohashi University of Technology)
// Created: 2023/5/14
// Summary: Manager of dropdown. Set and change tools.
// -----------------------------------------------------------------------

using UnityEngine;
using TMPro;

public class DropdownListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _valueRandomizerObj;

	[SerializeField]
	private GameObject _pixelTransratorObj;

	/// <summary>
	/// Change experiment tools.
	/// </summary>
	/// <param name="dropdown">dropdown of tool list</param>
	public void ChangeTools(TMP_Dropdown dropdown)
	{
		switch (dropdown.value)
		{
			case 0:
				_valueRandomizerObj.SetActive(true);
				_pixelTransratorObj.SetActive(false);
				break;
			case 1:
				_valueRandomizerObj.SetActive(false);
				_pixelTransratorObj.SetActive(true);
				break;
			case 2:
				_valueRandomizerObj.SetActive(false);
				_pixelTransratorObj.SetActive(false);
				break;
			default:
				break;
		}
	}
}
