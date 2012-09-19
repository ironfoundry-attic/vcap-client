namespace IronFoundry.Models
{
    using Newtonsoft.Json;

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