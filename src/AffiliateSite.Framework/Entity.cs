using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Framework
{
    public abstract class Entity<TId> : IInternalEventHandler
        where TId : ValueObject<TId>
    {
        private readonly Action<object> _applier;

        public TId Id { get; protected set; }

        protected Entity(Action<object> applier) => _applier = applier;

        protected Entity() { }

        protected abstract void When(object @event);

        protected void Apply(object @event)
        {
            When(@event);
        }

        void IInternalEventHandler.Handle(object @event) => When(@event);
    }
}
