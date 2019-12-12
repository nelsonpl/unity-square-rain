using Assets.Scripts.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Controller
{
    public class MainController : MonoBehaviour
    {
        public Text TxtScoreMax;

        void Start()
        {
            var scoreMax = PlayerPrefs.GetInt("SCORE_MAX");
            TxtScoreMax.text = scoreMax.ToString();
        }
        public void StartGame()
        {
            MultimediaController.ExecutePlay();
            SceneManager.LoadScene(Consts.SceneGame);
        }
    }
}
