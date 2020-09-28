using UnityEngine;
using UnityEditor;

public interface Initiable {
    void Init();

}

public interface IObservador
{
    void Notificar(GameObject ob, string Mensaje, object valor );
}