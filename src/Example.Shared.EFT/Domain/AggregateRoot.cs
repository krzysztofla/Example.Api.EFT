using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Shared.EFT.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }

        public int Version { get; protected set; }

        bool _vesrsionIncremented = false;

        protected void IncrementVersion()
        {
            if (_vesrsionIncremented)
            {
                return;
            }

            Version++;
            _vesrsionIncremented = true;
        }
    }
}
