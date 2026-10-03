using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int pieceID; // Set this in Inspector (0, 1, 2, ...) matching its correct slot ID

    private Image _image;
    private CanvasGroup _canvasGroup;
    private Vector3 _startPosition;
    private Transform _startParent;
    private bool _isLocked = false;

    void Awake()
    {
        _image = GetComponent<Image>();
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void Start()
    {
        _startPosition = transform.position;
        _startParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isLocked) return;

        // Make transparent to raycasts so Drop Slot under cursor can detect OnDrop
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.7f;

        // Bring dragged piece to front of Canvas
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isLocked) return;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isLocked) return;

        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1.0f;

        // If not dropped onto a valid target, return to starting position
        if (transform.parent == _startParent || transform.parent == transform.root)
        {
            ResetToStart();
        }
    }

    public void SnapToSlot(Transform slotTransform)
    {
        transform.SetParent(slotTransform);
        transform.localPosition = Vector3.zero;
    }

    public void LockPiece()
    {
        _isLocked = true;
        _canvasGroup.blocksRaycasts = false;
    }

    public void ResetToStart()
    {
        transform.SetParent(_startParent);
        transform.position = _startPosition;
    }
}   