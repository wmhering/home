using System;
using System.Collections.Generic;
using System.Text;

namespace Home.BO
{
    public class ConcurrencyResult<T>
    {
        public ConcurrencyResult(T data, bool concurrencyViolation = false)
        {
            Data = data;
            ConcurrencyViolation = concurrencyViolation;
        }

        public bool ConcurrencyViolation { get; private set; }

        public T Data { get; private set; }
    }
}
