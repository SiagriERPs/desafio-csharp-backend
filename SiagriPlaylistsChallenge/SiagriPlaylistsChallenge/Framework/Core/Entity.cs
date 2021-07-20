using System;
using System.Collections.Generic;
using System.Linq;


namespace SiagriPlaylistsChallenge.Framework.Core
{
    /// <summary>
    /// This is the base entity contract with some useful helpers for dealing with domain
    /// logic that is contained within the entities and Value Objects
    /// </summary>
    /// <summary>
    /// Essa entitidade base será usada para facilitar a aplicação de lógica de domínio
    /// os metodos <code>When</code>, <code>Apply</code> e <code>EnsureValidState</code>
    /// são facilitadores para a implementação de uma Observer Pattern
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public abstract class Entity<TId> where TId : IEquatable<TId>
    {
        private readonly List<object> _events;

        protected Entity() => _events = new List<object>();

        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _events.Add(@event);
        }

        protected abstract void When(object @event);

        public IEnumerable<object> GetChanges() => _events.AsEnumerable();

        public void ClearChanges() => _events.Clear();

        protected abstract void EnsureValidState();
    }
}