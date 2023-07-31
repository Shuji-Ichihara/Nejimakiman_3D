using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    GameObject _countsoulPrefab;
    GameObject _countsoul;
    public Soul _soul;

    [SerializeField]
    Text _tptext;
    private int moveCount = 10;
    [SerializeField]
    Text countText;
    [SerializeField]
    GameObject _tpEffects;
    GameObject portal;
    Vector2 Tppos;
    int Tpcount;
    [SerializeField]
    int Tp;

    //[SerializeField]
    //Animator _playeranim;
    Vector2 mPos;
    Vector3 screenSizeHalf;
    float rad;
    float previousRad;
    float tan;
    int split;
    int answer;
    int answersecond;
    int answerthird;
    int speed;
    int speedMaxplus;
    int soul;
    int soulcount;
    private bool move = false;
    public bool Moveplayer => move;   
    [SerializeField]
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        split = 6;
        speedMaxplus = 10;
        text.text = answersecond + "";
        _tptext.text = Tp + "";
        //UpdateCountText();

        //�}�E�X���񂵂Ă��锻����Ƃ�
        screenSizeHalf.x = Screen.width / 2f;
        screenSizeHalf.y = Screen.height / 2f;
        screenSizeHalf.z = 0f;
        mPos = Input.mousePosition - screenSizeHalf;
        previousRad = Mathf.Atan2(mPos.x, mPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //�}�E�X���񂵂Ă��锻����Ƃ�
            mPos = Input.mousePosition - screenSizeHalf;
            rad = Mathf.Atan2(mPos.x, mPos.y);
            float dRad = rad - previousRad;
            tan += Mathf.Tan(dRad);
            //�񂵂��񐔂��e�L�X�g�ɕ\��
            if( tan > split ) 
            {
                answer = (int)tan;
                answersecond = answer / split;
            }
            previousRad = rad;
        }
        if(answersecond > 0)
        {
            soulcount = answersecond;
            int soulspown = soulcount - soul;
            if (soulspown > 0)
            {
                Instantiate(_countsoulPrefab, Vector3.zero, Quaternion.identity);
                soulspown--;
            }
            soul = answersecond;
        }
        //�ړ������w��
        if(Input.GetMouseButtonUp(0)) 
        {
            //_playeranim.SetBool("Walk", true);
            answerthird = answersecond * speedMaxplus;
            answer = 0;
            StartCoroutine("Move");
            text.text = answer + "";
            _soul.SoulMax = 0;
            moveCount--;
            if(moveCount <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            UpdateCountText();
        }
        //�e���|�[�g
        if (Tp > 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Tpcount++;
                //�e���|�[�g�ʒu�w��&���̏ꏊ�̉���
                if (Tpcount == 1)
                {
                    Instantiate(_tpEffects, this.transform.position, Quaternion.identity);
                    Tppos = this.transform.position;
                }
                //�e���|�[�g&�|�[�^���폜
                else if (Tpcount == 2)
                {
                    this.transform.position = Tppos;
                    Tpcount = 0;
                    Tp--;
                    _tptext.text = Tp + "";
                    portal = GameObject.Find("TpEffects(Clone)");
                    Destroy(portal);
                }
            }
        }
        else if(Tp <= 0)
        {
            _tptext.transform.position = new Vector2(-4.5f,4);
            _tptext.rectTransform.sizeDelta = new Vector2(175,30);
            _tptext.fontSize = 13;
            _tptext.text = "テレポートは使い切りました";
        }
    }
    //�ړ�
    IEnumerator Move()
    {
        while (speed < answerthird)
        {
            move = true;
            speed++;
            transform.Translate(0.06f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        answersecond = 0;
        answerthird = 0;
        speed = 0;
        tan = 0f;
        move = false;
        //_playeranim.SetBool("Walk", false);
    }
    private void UpdateCountText()
    {
        countText.text = moveCount.ToString();
    }
}
