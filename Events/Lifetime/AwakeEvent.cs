﻿namespace Mutiny.Foundation.Events
{
    public class AwakeEvent : SimpleEvent
    {
        private void Awake() => this.Event.Invoke();
    }
}