using IoT.WCD.BlockChain.Storage.LocalMemento;

namespace IoT.WCD.BlockChain.Storage
{
    public interface IOriginator
    {
        Memento GetMemento();

        void SetMemento(Memento memento);
    }
}
