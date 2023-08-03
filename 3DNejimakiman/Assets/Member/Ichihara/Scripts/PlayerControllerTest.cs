using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    // 描いた円の挙動の分割
    [SerializeField]
    private int _split = 6;

    // ボタンを押した座標
    private Vector2 _coordinatesOfMouseButtonPress = Vector3.zero;
    private Vector3 _halfScreenSize = Vector3.zero;

    private float _tan = 0;
    // マウスの移動量
    private float _previousRadian = 0;
    private int _moveDistance = 0;

    private bool _doOnce = false;

    private CancellationTokenSource _token = new CancellationTokenSource();

    // Start is called before the first frame update
    void Start()
    {
        _halfScreenSize.x = Screen.width / 2;
        _halfScreenSize.y = Screen.height / 2;
        _previousRadian = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (false == _doOnce)
        {
            if (Input.GetMouseButton(0))
            {
                DragMouse();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _doOnce = true;
                UpMouse();
            }
        }
    }

    /// <summary>
    /// マウスをドラッグしている間の処理
    /// </summary>
    private void DragMouse()
    {
        _coordinatesOfMouseButtonPress = Input.mousePosition - _halfScreenSize;
        float radian = Mathf.Atan2(_coordinatesOfMouseButtonPress.x
            , _coordinatesOfMouseButtonPress.y);
        float dRadian = radian - _previousRadian;
        _tan += Mathf.Tan(dRadian);
        if (_tan > _split)
        {
            int dummyMoveDistance = (int)_tan;
            _moveDistance = dummyMoveDistance / _split;
        }
        _previousRadian = radian;
    }

    /// <summary>
    /// マウスを離した時の処理
    /// </summary>
    private void UpMouse()
    {
        MovePlayer(_moveDistance, _token).Forget();
    }

    private async UniTask MovePlayer(int moveDistance, CancellationTokenSource token = default)
    {
        float amountOfPlayerMovement = 0.0f;
        float playerOntheMove = 0.0f;
        Vector3 movePlayerVector = Vector3.right;
        while (amountOfPlayerMovement < moveDistance)
        {
            playerOntheMove = moveDistance * Time.deltaTime;
            amountOfPlayerMovement += playerOntheMove;
            transform.Translate(movePlayerVector * playerOntheMove);
            await UniTask.DelayFrame(1, cancellationToken: token.Token);
        }
        _doOnce = false;
    }
}
