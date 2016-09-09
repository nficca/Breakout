using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

    private int score;
    private int brickMultiplier;
    private int rallyMultiplier;

    public Text scoreText;
    public Text brickMultiplierText;
    public Text rallyMultiplierText;

	// Use this for initialization
	void Start () {
        score = 0;
        brickMultiplier = 1;
        rallyMultiplier = 1;
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {

	}

    // Resets mutliplier for bricks to 1
    public void ResetBrickMultiplier() {
        brickMultiplier = 1;
        UpdateUI();
    }

    // Resets multiplier for paddle to 1
    public void ResetRallyMultiplier() {
        rallyMultiplier = 1;
        UpdateUI();
    }

    // Resets all multipliers to base value
    public void ResetAllMultipliers() {
        brickMultiplier = 1;
        rallyMultiplier = 1;
        UpdateUI();
    }

    // Adds points to score
    public void AddPoints(int points = 1) {
        int multiplier = 1;
        if (brickMultiplier > 1) multiplier += brickMultiplier;
        if (rallyMultiplier > 1) multiplier += rallyMultiplier;
        score += points * multiplier;
        UpdateUI();
    }

    // Increase brick score multiplier by amount
    public void IncreaseBrickMultiplier(int amound = 1) {
        brickMultiplier += 1;
        UpdateUI();
    }

    // Increase paddle score multiplier by amount
    public void IncreaseRallyMultiplier(int amount = 1) {
        rallyMultiplier += 1;
        UpdateUI();
    }

    private void UpdateUI() {
        scoreText.text = "" + score;
        brickMultiplierText.text = "x" + brickMultiplier;
        rallyMultiplierText.text = "x" + rallyMultiplier;
    }


}
