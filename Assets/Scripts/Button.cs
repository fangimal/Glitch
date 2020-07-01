using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{

	public GameObject defenderPrefab;
	public static GameObject selectedDefender; //Отслеживает какие дефендеры нажаты/ выделены

	private Button[] buttonArray;
	private Text costText;

	void Start()
	{
		buttonArray = GameObject.FindObjectsOfType<Button>();

		costText = GetComponentInChildren<Text>(); //Получить дочерний объект Текст
		if (!costText) { Debug.LogWarning(name + " У объекта отсутствует компонет Текст"); }

		//Передадим значения со стоимостью дефендеров в текстовое поле, при покупке
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

	void Update()
	{

	}

	void OnMouseDown()
	{
		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
