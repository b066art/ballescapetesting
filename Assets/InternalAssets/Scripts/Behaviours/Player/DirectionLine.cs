using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class DirectionLine : MonoBehaviour
{
    [SerializeField] private float lineStartWidth, lineEndWidth, lineMaxLength, lineLengthFactor;
    [SerializeField] private string startColorHex, endColorHex;

    private Camera mainCamera;
    private LineRenderer lineRenderer;
    private PlayerInput playerInput;

    private Vector2 pointerStartPosition;
    private Vector2 pointerEndPosition;

    private bool drawing = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();

        AddLineRenderer();
    }

    private void OnEnable()
    {
        playerInput.OnStartDrag += OnStartDrag;
        playerInput.OnEndDrag += OnEndDrag;
    }

    private void OnDisable()
    {
        playerInput.OnStartDrag -= OnStartDrag;
        playerInput.OnEndDrag -= OnEndDrag;
    }

    private void OnStartDrag()
    {
        StartCoroutine("Drawing");
    }

    private void OnEndDrag()
    {
        drawing = false;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.zero);
        }
    }

    IEnumerator Drawing()
    {
        drawing = true;
        pointerStartPosition = GetCurrentWorldPoint();
        
        while (drawing)
        {
            SetStartPoint();
            SetEndPoint();
            yield return null;
        }
    }

    private void SetStartPoint()
    {
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y);
        lineRenderer.SetPosition(0, startPosition);
    }

    private void SetEndPoint()
    {
        pointerEndPosition = GetCurrentWorldPoint();
        Vector2 direction = Vector2.ClampMagnitude((pointerEndPosition - pointerStartPosition) * lineLengthFactor, lineMaxLength);
        Vector2 endPosition = new Vector2(transform.position.x, transform.position.y) + direction;
        lineRenderer.SetPosition(1, endPosition);
    }

    private Vector2 GetCurrentWorldPoint()
    {
        Vector3 pointerPosition = playerInput.GetPointerPosition();
        pointerPosition.z = -mainCamera.transform.position.z;
        return pointerPosition;
    }

    private void AddLineRenderer()
    {
        Color newCol;

        lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, Vector3.zero);
        }

        lineRenderer.startWidth = lineStartWidth;
        lineRenderer.endWidth = lineEndWidth;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        if (ColorUtility.TryParseHtmlString(startColorHex, out newCol))
            lineRenderer.startColor = newCol;
        if (ColorUtility.TryParseHtmlString(endColorHex, out newCol))
            lineRenderer.endColor = newCol;
    }
}