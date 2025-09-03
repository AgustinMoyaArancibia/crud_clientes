using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Results
{
    public class Result<T>
    {
        public bool Succeeded { get; }
        public T? Value { get; }
        public string? Error { get; }

        private Result(bool ok, T? value, string? error)
            => (Succeeded, Value, Error) = (ok, value, error);

        public static Result<T> Success(T value) => new(true, value, null);
        public static Result<T> Failure(string message) => new(false, default, message);
    }
}
