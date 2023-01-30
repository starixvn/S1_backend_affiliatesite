using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.Framework
{
    public abstract class Entity<TId> where TId : IEquatable<TId>
    {
        private readonly List<object> _events;

        protected Entity() => _events = new List<object>();

        protected void Apply(object @event)
        {
            When(@event);
            _events.Add(@event);
        }
        //改變系統狀態
        protected abstract void When(object @event);

        //檢索事件
        public IEnumerable<object> GetChanges() => _events.AsEnumerable();

        //清除事件
        public void ClearChanges() => _events.Clear();
    }
}
