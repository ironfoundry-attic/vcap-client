// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace IronFoundry.Models
{
    public abstract class Message : EntityBase
    {
        public const string ReceiveOnly = "RECEIVE_ONLY";
        public const string ReplyOk = "REPLY_OK";

        [JsonIgnore]
        public virtual string PublishSubject
        {
            get { return ReceiveOnly; }
        }

        [JsonIgnore]
        public string RawJson { get; set; }
    }
}