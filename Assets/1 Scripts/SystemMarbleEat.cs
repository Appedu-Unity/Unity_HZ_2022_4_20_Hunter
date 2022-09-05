using UnityEngine;

namespace WEI {
    public class SystemMarbleEat : MonoBehaviour
    {
        private string nameMarblePlayer = "ª÷ÄÝ²y";
        private SystemTurn systemTurn;

        private void Awake()
        {
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
