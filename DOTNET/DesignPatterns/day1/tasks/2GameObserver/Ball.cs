namespace _2GameObserver
{
    internal class Ball: IPublisher
    {
        List<IObserver<Position>> observers = new();

        public void AttachObserver(IObserver<Position> observer)
        {
            observers.Add(observer);
        }

        public void DetachObserver(IObserver<Position> observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(Position position)
        {
            foreach (var observer in observers)
            {
                try
                {
                    observer.OnNext(position);
                }
                catch (Exception ex) 
                {
                    observer.OnError(ex);
                }
                finally
                {
                    observer.OnCompleted();
                }
            }
        }
    }
}