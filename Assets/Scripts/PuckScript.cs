using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreController ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public float MaxSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreController.Score.PlayerScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreController.Score.AiScore);
                WasGoal = true;
                StartCoroutine(ResetPuck(true));
            }
        }
    }


    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }

    public void CenterPuck()
    {
        rb.position = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
