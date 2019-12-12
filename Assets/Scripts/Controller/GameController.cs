using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Controller
{
    public class GameController : MonoBehaviour
    {
        public Text TxtGOScore;
        public Text TxtGOMaxScore;
        public Text TxtScore;
        public Text TxtLevel;
        public Text TxtQteShape;

        public GameObject BtnPause;
        public GameObject Shape;
        public GameObject DangerGameOver;
        public GameObject Tail;
        public GameObject PanelGameOver;
        public GameObject PanelGamePaused;
        public GameObject PanelTopScore;
        public GameObject PanelDebug;

        public GameObject HeartFull01;
        public GameObject HeartFull02;
        public GameObject HeartFull03;
        public GameObject HeartEmpty01;
        public GameObject HeartEmpty02;
        public GameObject HeartEmpty03;


        private int _score;
        private int _scoreMax;
        private int _qteLife;
        private bool _isExecute;
        private bool _isGameOver;

        private RandomList<EShapePosition> _pList;
        private RandomList<EShapeType> _tList;
        private RandomList<EShapeVelocity> _vList;

        private static GameController _instance;
        public static GameController Instance { get { return _instance; } }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        void Start()
        {
            _pList = new RandomList<EShapePosition>();
            _pList.Add(EShapePosition.Left);
            _pList.Add(EShapePosition.LeftCenter);
            _pList.Add(EShapePosition.Center);
            _pList.Add(EShapePosition.RightCenter);
            _pList.Add(EShapePosition.Right);

            _tList = new RandomList<EShapeType>();
            _tList.Add(EShapeType.DangerGameOver);
            _tList.Add(EShapeType.Normal);

            _vList = new RandomList<EShapeVelocity>();
            _vList.Add(EShapeVelocity.Slow);
            _vList.Add(EShapeVelocity.Slow);
            _vList.Add(EShapeVelocity.Slow);
            _vList.Add(EShapeVelocity.Slow);
            _vList.Add(EShapeVelocity.Slow);
            _vList.Add(EShapeVelocity.Normal);
            _vList.Add(EShapeVelocity.Normal);
            _vList.Add(EShapeVelocity.Normal);
            _vList.Add(EShapeVelocity.Normal);
            _vList.Add(EShapeVelocity.Fast);
            _vList.Add(EShapeVelocity.Fast);
            _vList.Add(EShapeVelocity.Fast);
            _vList.Add(EShapeVelocity.VeryFast);
            _vList.Add(EShapeVelocity.VeryFast);

            PanelDebug.SetActive(false);
            Time.timeScale = 1;
            _score = 0;
            _scoreMax = PlayerPrefs.GetInt("SCORE_MAX");

            TxtScore.text = _score.ToString();

            _qteLife = 3;

            InvokeRepeating("GetTouches", 0, 0.01f);
            StartCoroutine(WaitAndCreateShapes());
        }

        void Update()
        {
            //print(BoardController.Instance.ToString());
        }

        internal void GameOver()
        {
            if (_isGameOver)
            {
                return;
            }
            _isGameOver = true;
            MultimediaController.ExecuteGameOver();
            PanelGameOver.SetActive(true);
            PanelTopScore.SetActive(false);
            BtnPause.SetActive(false);
            TxtGOMaxScore.text = _scoreMax.ToString();
            TxtGOScore.text = TxtScore.text;
            PlayerPrefs.SetInt("SCORE", _score);
            PlayerPrefs.SetInt("SCORE_MAX", _scoreMax);
            CancelInvoke();
            _isExecute = false;
        }

        internal void RemoveLife()
        {
            _qteLife--;
            switch (_qteLife)
            {
                case 2:
                    HeartEmpty01.SetActive(true);
                    HeartFull01.SetActive(false);
                    break;
                case 1:
                    HeartEmpty02.SetActive(true);
                    HeartFull02.SetActive(false);
                    break;
                case 0:
                    HeartEmpty03.SetActive(true);
                    HeartFull03.SetActive(false);
                    GameOver();
                    break;
            }
        }

        public void BtnMainClick()
        {
            SceneManager.LoadScene(Consts.SceneMain);

        }

        public void BtnRestartClick()
        {
            SceneManager.LoadScene(Consts.SceneGame);
        }

        public void BtnPauseClick()
        {
            PanelGamePaused.SetActive(true);
            BtnPause.SetActive(false);
            Time.timeScale = 0;
        }

        public void BtnResumeClick()
        {
            PanelGamePaused.SetActive(false);
            BtnPause.SetActive(true);
            Time.timeScale = 1;
        }

        void GetTouches()
        {
            var myTouches = Input.touches;

            foreach (var t in myTouches)
            {

                if (t.phase == TouchPhase.Began)
                {
                    MultimediaController.ExecuteGesture();
                }

                if (t.phase != TouchPhase.Moved)
                {
                    continue;
                }

                var wp = Camera.main.ScreenToWorldPoint(t.position);
                var touchPos = new Vector3(wp.x, wp.y, 0);

                var tail = Instantiate(Tail);
                tail.transform.position = touchPos;

                DestroyShapes(touchPos);
            }

        }

        void DestroyShapes(Vector2 touchPos)
        {
            var shapes = Physics2D.OverlapPointAll(touchPos);

            foreach (var item in shapes)
            {
                var shapeScript = item.GetComponent<ShapeController>();
                if (shapeScript != null)
                {
                    switch (shapeScript.EType)
                    {
                        case EShapeType.Normal:
                            AddScore();
                            break;
                        case EShapeType.DangerGameOver:
                            GameOver();
                            break;
                    }

                    item.GetComponent<ShapeController>().Destroy();
                }
            }

        }

         public void AddScore()
        {
            _score++;
            TxtScore.text = _score.ToString();

            if (_score >= _scoreMax)
            {
                _scoreMax = _score;
            }
        }
        IEnumerator WaitAndCreateShapes()
        {
            _isExecute = true;
            var count = 1;
            yield return new WaitForSeconds(2);
            var configs = new ConfigExecuteManager().GetConfigs();

            for (int i = 0; i < configs.Count && _isExecute; i++)
            {
                for (int j = 0; j < configs[i].CountExecute; j++)
                {
                    //yield return new WaitForSeconds(0.1725f);
                    yield return new WaitForSeconds(Utils.GetInterval(configs[i].EInterval));

                    var shape = Instantiate(count == 5 ? DangerGameOver : Shape);
                    var shapeScript = shape.GetComponent<ShapeController>();
                    shapeScript.Init(count == 5 ? EShapeType.DangerGameOver : EShapeType.Normal, _pList.Get(), configs[i].EVelocity);
                    if (count == 5)
                    {
                        count = 0;
                    }
                    count++;
                }
            }
        }

        //IEnumerator WaitAndCreateShapesOld()
        //{
        //    _isExecute = true;
        //    var configManager = new ConfigExecuteManager();

        //    while (_isExecute)
        //    {
        //        yield return new WaitForSeconds(configManager.IntervalStart);
        //        var config = configManager.GetConfig();

        //        if (config.IsEmpty)
        //        {
        //            SceneManager.LoadScene(Consts.SceneMain);
        //            _isExecute = false;
        //            break;
        //        }

        //        for (int i = 0; i < config.Items.Count && _isExecute; i++)
        //        {
        //            yield return new WaitForSeconds(Utils.GetInterval(config.EInterval));
        //            var shape = Instantiate(config.Items[i].EShapeType == EShapeType.Normal ? Shape : DangerGameOver);
        //            var shapeScript = shape.GetComponent<ShapeController>();
        //            shapeScript.Init(config.Items[i]);
        //        }
        //    }
        //}

    }
}