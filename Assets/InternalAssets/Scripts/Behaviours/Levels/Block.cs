using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] private float defaultMass, minScale, maxScale;

    private Rigidbody rb;

    float blockScale = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        SetScale();
        SetWeight();
    }

    private void SetScale()
    {
        blockScale = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3 (blockScale, blockScale, 1);
    }

    private void SetWeight()
    {
        rb.mass = defaultMass * blockScale;
    }
}
