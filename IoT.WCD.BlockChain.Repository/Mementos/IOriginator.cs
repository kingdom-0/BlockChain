namespace IoT.WCD.BlockChain.Repository.Mementos
{
    public interface IOriginator
    {
        Memento GetMemento();

        void SetMemento(Memento memento);
    }
}
