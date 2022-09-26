using UnityEngine;

namespace WEI
{
    public class SystemMarbleEat : MonoBehaviour
    {
        private string nameMarblePlayer = "���ݲy";
        private SystemTurn systemTurn;

        private void Awake()
        {
            //�z�L�����M�䪫��<����>()
            //* �j�M�����������W�u�঳�@��
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
