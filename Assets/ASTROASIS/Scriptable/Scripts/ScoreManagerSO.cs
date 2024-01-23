using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreManagerSO", menuName = "Scriptable/Score Manager")]
public class ScoreManagerSO : ScriptableObject
{
    /// <summary>
    /// Player score
    /// </summary>
    private int score = 0;

    /// <summary>
    /// Event called when score changes
    /// </summary>
    [System.NonSerialized]
    public UnityEvent<int> scoreChangeEvent;

    private void OnEnable()
    {
        this.score = 0;
        if (scoreChangeEvent != null )
            scoreChangeEvent = new UnityEvent<int>();
    }

    public void IncreaseScore(int score)
    {
        this.score += score;
    }
}
