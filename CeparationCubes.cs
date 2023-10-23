using UnityEngine;

public class CeparationCubes : MonoBehaviour
{
    //private bool _collisionSet;

    private void OnCollisionEnter(Collision collision) //������� ����� �������� ������ �����,
                                                       //����� ���������� ��������������� ����-���� � ��������� ���������� Ground,
                                                       //� ����� ������ ��� ��������������� ����� ����� � Ground.
                                                       //collision - ��� ������, ������� �������������.
    {
        if(collision.gameObject.tag == "Cube") //��� ����� ���������, � ����� �������� ������������� "���" ����.
                                               //�� ���������� � collision, � ���� �������, ������� �����������.
                                               //���������� � gameObject, � �� ���������� ������ �� ����, ������� ������� �����
                                               //��� ���������� ������� � ����� "Cube"
        {
            for(int i = collision.transform.childCount-1; i>=0; i--)//���������� �������� ������� � �����,
                                                                    //������ ��� �� ����� ���� ������������� ����������.
                                                                    //���������� � childCount - ��� ������� �������� ���������,
                                                                    //� (-1) ������ ��� ���������� ������ 0.
                                                                    //(i>=0) - �������. ���������, ���� i>=0.
                                                                    //(i--) - ������ ��� ��������� i �� 1.
            {
                Transform child = collision.transform.GetChild(i); //������� ���������� � ����� ������ Transform.
                                                                   //������� GetChild ��������� ������� ������������
                                                                   //������� �� ��� �������. GetChild(i) ��������,
                                                                   //��� �� �������� ��� �������� ��������.

                child.gameObject.AddComponent<Rigidbody>(); //���������� � child ��� � �������� �������.
                                                            //� ���� ��������� ��������� <Rigidbody>.
                child.gameObject.GetComponent<Rigidbody>().AddExplosionForce(70f, Vector3.up, 25f);//������ �� ��� �������� ���������.
                                                                                                   //������� AddExplosionForce() ���������
                                                                                                   //�������� �������� ����.
                                                                                                   //70f - ���� ������.
                                                                                                   //Vector3.up - ������ � ������� �����
                                                                                                   //����������� ����,
                                                                                                   //� ��� ���������� ���� �� ���������� �.
                                                                                                   //������ �������� (25f) - ��� ������ ��������.
                child.SetParent(null);//����� ������� �� �������� ���� �� �����.
                                      //SetParent(null) ��������, ��� � ������� ��������� ������� �� ����� ��������
            }
            Destroy(collision.gameObject);//����� ��������������� �� ����� ������� All Cubes.
            //_collisionSet = true;
        }
    }
}
