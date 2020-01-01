using System.Collections;
using Navigation;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemySpawnPoints;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private AnimationCurve spawnAnimationCurve;
    [SerializeField] private CanvasGroup theButtons;

    private int _enemyCount;

    enum BattlePhase
    {
        PlayerAttack,
        EnemyAttack
    }

    private BattlePhase _phase;

    private void Start()
    {
        _enemyCount = Random.Range(1, enemySpawnPoints.Length);
        StartCoroutine(SpawnEnemies());
        _phase = BattlePhase.PlayerAttack;
    }

    private void Update()
    {
        if (_phase == BattlePhase.PlayerAttack)
        {
            theButtons.alpha = 1;
            theButtons.interactable = true;
            theButtons.blocksRaycasts = true;
        }
        else
        {
            theButtons.alpha = 0;
            theButtons.interactable = false;
            theButtons.blocksRaycasts = false;
        }
    }

    public void RunAway()
    {
        GameState.JustExitedBattle = true;
        NavigationManager.NavigateTo("Overworld");
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var newEnemy = Instantiate(enemyPrefab[0]);
            newEnemy.transform.position = new Vector3(10, -1, 0);

            yield return StartCoroutine(MoveCharacterToPoint(enemySpawnPoints[i], newEnemy));
            newEnemy.transform.parent = enemySpawnPoints[i].transform;
        }
    }

    IEnumerator MoveCharacterToPoint(GameObject destination, GameObject character)
    {
        float timer = 0f;
        var startPosition = character.transform.position;
        if (spawnAnimationCurve.length > 0)
        {
            while (timer < spawnAnimationCurve.keys[spawnAnimationCurve.length - 1].time)
            {
                character.transform.position = Vector3.Lerp(startPosition, destination.transform.position,
                    spawnAnimationCurve.Evaluate(timer));
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            character.transform.position = destination.transform.position;
        }
    }
}