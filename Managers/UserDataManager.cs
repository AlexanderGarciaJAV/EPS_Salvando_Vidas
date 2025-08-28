using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Fase3JavierGarcia.Managers
{
    public class UserDataManager
    {
        public Stack<EstructuraDatosUsuario> PilaUsuarios { get; } = new Stack<EstructuraDatosUsuario>();
        public Queue<EstructuraDatosUsuario> ColaUsuarios { get; } = new Queue<EstructuraDatosUsuario>();
        public List<EstructuraDatosUsuario> ListaUsuarios { get; } = new List<EstructuraDatosUsuario>();

        public void AddUserToStack(EstructuraDatosUsuario user) => PilaUsuarios.Push(user);
        public void AddUserToQueue(EstructuraDatosUsuario user) => ColaUsuarios.Enqueue(user);
        public void AddUserToList(EstructuraDatosUsuario user) => ListaUsuarios.Add(user);

        public EstructuraDatosUsuario PopUserFromStack() => PilaUsuarios.Pop();
        public EstructuraDatosUsuario DequeueUserFromQueue() => ColaUsuarios.Dequeue();
        public void RemoveUserFromList(int index) => ListaUsuarios.RemoveAt(index);
    }
}
