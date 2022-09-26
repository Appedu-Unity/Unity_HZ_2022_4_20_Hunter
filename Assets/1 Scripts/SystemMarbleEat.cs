using UnityEngine;

namespace WEI
{
    public class SystemMarbleEat : MonoBehaviour
    {
        private string nameMarblePlayer = "金屬球";
        private SystemTurn systemTurn;

        private void Awake()
        {
            //透過類型尋找物件<類型>()
            //* 搜尋的類型場景上只能有一個
            systemTurn = FindObjectOfType<SystemTurn>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameMarblePlayer))
            {
                systemTurn.MarbleEat();
                Destroy(gameObject);
            }
        }
    }
}
