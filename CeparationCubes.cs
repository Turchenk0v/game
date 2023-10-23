using UnityEngine;

public class CeparationCubes : MonoBehaviour
{
    //private bool _collisionSet;

    private void OnCollisionEnter(Collision collision) //функция будет работать только тогда,
                                                       //когда произойдет соприкосновение чего-либо с невидимой платформой Ground,
                                                       //в нашем случае это соприкосновение кубов башни с Ground.
                                                       //collision - это объект, который соприкоснулся.
    {
        if(collision.gameObject.tag == "Cube") //нам нужно проверять, с каким объектом соприкоснулся "пол" игры.
                                               //мы обращаемся к collision, к тому объекту, который прикоснулся.
                                               //обращаемся к gameObject, и мы определяем объект по тегу, который вводили ранее
                                               //нас интересуют объекты с тегом "Cube"
        {
            for(int i = collision.transform.childCount-1; i>=0; i--)//перебираем дочерние объекты с конца,
                                                                    //потому что их может быть неограниченое количество.
                                                                    //обращаемся к childCount - это подсчет дочерних элементов,
                                                                    //а (-1) потому что существует индекс 0.
                                                                    //(i>=0) - условие. Выполнять, пока i>=0.
                                                                    //(i--) - каждый раз уменьшаем i на 1.
            {
                Transform child = collision.transform.GetChild(i); //создаем переменную с типом данных Transform.
                                                                   //функция GetChild позволяет выбрать определенный
                                                                   //элемент по его индексу. GetChild(i) означает,
                                                                   //что мы переберём все дочерние элементы.

                child.gameObject.AddComponent<Rigidbody>(); //обращаемся к child как к игровому объекту.
                                                            //к нему добавляем компонент <Rigidbody>.
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(70f, Vector3.up, 25f);//теперь мы уже получаем компонент.
                                                                                                   //функция AddExplosionForce() позволяет
                                                                                                   //добавить взрывную силу.
                                                                                                   //70f - сила взрыва.
                                                                                                   //Vector3.up - вектор в котором будет
                                                                                                   //выполняться сила,
                                                                                                   //у нас добавление силы по координате У.
                                                                                                   //Третий параметр (25f) - это радиус действия.
                child.SetParent(null);//чтобы объекты не зависили друг от друга.
                                      //SetParent(null) означает, что у каждого дочернего объекта не будет родителя
            }
            Destroy(collision.gameObject);//после соприкосновения мы будем удалять All Cubes.
            //_collisionSet = true;
        }
    }
}
