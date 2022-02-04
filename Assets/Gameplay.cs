using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public List<RectTransform> playerDeck = new List<RectTransform>();
    public List<RectTransform> enemyDeck = new List<RectTransform>();
    public Text resultText;
    public GameObject resetButton;

    public float offset;

    public void Choose(int value)
    {
        playerDeck[value].anchoredPosition = new Vector2(playerDeck[value].anchoredPosition.x, playerDeck[value].anchoredPosition.y + offset);
        StartCoroutine(CheckEnemy(value + 1));
    }

    private void DisablePlayerButton()
    {
        for(int i = 0; i < playerDeck.Count; i++)
        {
            playerDeck[i].gameObject.GetComponent<Button>().interactable = false;
        }
    }

    private void EnablePlayerButton()
    {
        for (int i = 0; i < playerDeck.Count; i++)
        {
            playerDeck[i].gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void ResetGame()
    {
        for(int i = 0; i < playerDeck.Count; i++)
        {
            playerDeck[i].anchoredPosition = new Vector2(playerDeck[i].anchoredPosition.x, 0);
            enemyDeck[i].anchoredPosition = new Vector2(enemyDeck[i].anchoredPosition.x, 0);
        }

        EnablePlayerButton();

        resultText.gameObject.SetActive(false);
        resetButton.SetActive(false);

    }

    private IEnumerator CheckEnemy(int playerValue)
    {
        DisablePlayerButton();
        yield return new WaitForSeconds(1);

        int enemyValue = Random.Range(1, 4);

        enemyDeck[enemyValue - 1].anchoredPosition = new Vector2(enemyDeck[enemyValue - 1].anchoredPosition.x, enemyDeck[enemyValue - 1].anchoredPosition.y - offset);

        resultText.gameObject.SetActive(true);
        resetButton.SetActive(true);
        //compare
        if(((enemyValue % 3) + 1) == playerValue)
        {
            Debug.Log("Menang");
            resultText.text = "MENANG";
        }
        else if(((playerValue % 3) + 1) == enemyValue)
        {
            Debug.Log("Kalah");
            resultText.text = "KALAH";
        }
        else
        {
            Debug.Log("Seri");
            resultText.text = "SERI";
        }

    }
}
