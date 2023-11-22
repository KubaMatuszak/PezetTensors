using System;
using System.Collections.Generic;

namespace ZImageTests.VM.Reactive
{
    public class Publisher<T>
    {
        public List<Action<T>> SubscribedActionsT  = new List<Action<T>>();
        public List<Action> SubscribedActions  = new List<Action>();
        public Publisher<T> Subscribe(Action<T> action)
        {  
            SubscribedActionsT.Add(action); 
            return this; 
        }

        public Publisher<T> Subscribe(Action action)
        {
            SubscribedActions.Add(action);
            return this;
        }



        public void Publish(T tObj)
        {
            RunTyped(tObj);
            RunNonTyped();
        }

        public void Publish()
        {
            RunTyped(default);
            RunNonTyped();
        }

        private void RunTyped(T tObj)
        {
            foreach (var action in SubscribedActionsT)
            {
                if (action == null)
                    continue;

                action(tObj);
            }
        }

        private void RunNonTyped()
        {
            foreach (var action in SubscribedActions)
            {
                if (action == null)
                    continue;
                action();
            }
        }


    }

    public class Publisher
    {
        public List<Action> SubscribedActions = new List<Action>();
        public Publisher Subscribe(Action action)
        {
            SubscribedActions.Add(action);
            return this;
        }

        public void Publish()
        {
            foreach (var action in SubscribedActions)
            {
                if (action == null)
                    continue;
                action();
            }
        }
    }

}
