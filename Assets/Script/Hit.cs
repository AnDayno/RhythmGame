using UnityEngine;

public abstract class Hit
{
    public abstract int Score { get; }
    public abstract void Apply(GameManager gameManager, Vector3 position, GameObject effectPrefab);
}

public class GoodHit : Hit
{
    public override int Score => 100;

    public override void Apply(GameManager gameManager, Vector3 position, GameObject effectPrefab)
    {
        gameManager.CurrentScore += Score * gameManager.CurrentMultiplier;
        gameManager.ArrowHit();
        if (effectPrefab != null)
        {
            Object.Instantiate(effectPrefab, position, Quaternion.identity);
        }
    }
}

public class GreatHit : Hit
{
    public override int Score => 125;

    public override void Apply(GameManager gameManager, Vector3 position, GameObject effectPrefab)
    {
        gameManager.CurrentScore += Score * gameManager.CurrentMultiplier;
        gameManager.ArrowHit();
        if (effectPrefab != null)
        {
            Object.Instantiate(effectPrefab, position, Quaternion.identity);
        }
    }
}

public class PerfectHit : Hit
{
    public override int Score => 150;

    public override void Apply(GameManager gameManager, Vector3 position, GameObject effectPrefab)
    {
        gameManager.CurrentScore += Score * gameManager.CurrentMultiplier;
        gameManager.ArrowHit();
        if (effectPrefab != null)
        {
            Object.Instantiate(effectPrefab, position, Quaternion.identity);
        }
    }
}

public class MissHit : Hit
{
    public override int Score => 0;

    public override void Apply(GameManager gameManager, Vector3 position, GameObject effectPrefab)
    {
        gameManager.ArrowMiss();
        if (effectPrefab != null)
        {
            Object.Instantiate(effectPrefab, position, Quaternion.identity);
        }
    }
}
