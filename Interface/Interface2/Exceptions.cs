using System;

namespace Interface2
{
    public class ExceptionsTest
    {
        class IsAbsentException : Exception
        {
        public IsAbsentException() : base() { }
        public IsAbsentException(string str) : base(str) { }
        public IsAbsentException(string str, Exception inner) : base(str, inner) { }
        public IsAbsentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
 
    class IsExpiredException : Exception
    {
        public IsExpiredException() : base() { }
        public IsExpiredException(string str) : base(str) { }
        public IsExpiredException(string str, Exception inner) : base(str, inner) { }
        public IsExpiredException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
 
    class IsDefectiveException : Exception
    {
        public IsDefectiveException() : base() { }
        public IsDefectiveException(string str) : base(str) { }
        public IsDefectiveException(string str, Exception inner) : base(str, inner) { }
        public IsDefectiveException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    }
}