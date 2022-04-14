﻿using NSI.Common.Enumerations;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace NSI.Common.Exceptions
{
    [Serializable]
    public abstract class NsiBaseException : Exception
    {
        protected NsiBaseException()
        {
        }

        protected NsiBaseException(string message)
            : base(message)
        {
        }

        protected NsiBaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NsiBaseException(string message, Severity severity)
            : base(message)
        {
            this.Severity = severity;
        }

        protected NsiBaseException(string message, Exception innerException, Severity severity)
            : base(message, innerException)
        {
            this.Severity = severity;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected NsiBaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Severity = (Severity)info.GetValue("Severity", typeof(Severity));
        }

        public Severity Severity { get; }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Severity", this.Severity);

            base.GetObjectData(info, context);
        }
    }
}
