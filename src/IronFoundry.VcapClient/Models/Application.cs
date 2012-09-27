// -----------------------------------------------------------------------
// <copyright file="Application.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IronFoundry.Models
{
    [Serializable]
    public class Application : EntityBase
    {
        private readonly List<string> _services = new List<string>();
        private int _instances;
        private string _name;
        private AppResources _resources;
        private int? _runningInstances;
        private Staging _staging;
        private string _state;
        private string _version;

        public Application()
        {
            Staging = new Staging();
            Resources = new AppResources();
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [JsonProperty(PropertyName = "staging")]
        public Staging Staging
        {
            get { return _staging; }
            set { _staging = value; }
        }

        [JsonProperty(PropertyName = "uris")]
        public string[] Uris { get; set; }

        [JsonProperty(PropertyName = "instances")]
        public int InstanceCount
        {
            get { return _instances; }
            set { _instances = value; }
        }

        [JsonProperty(PropertyName = "runningInstances")]
        public int? RunningInstances
        {
            get { return _runningInstances; }
            set { _runningInstances = value; }
        }

        [JsonProperty(PropertyName = "resources")]
        public AppResources Resources
        {
            get { return _resources; }
            set { _resources = value; }
        }

        [JsonProperty(PropertyName = "state")]
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        [JsonProperty(PropertyName = "services")]
        public string[] Services
        {
            get { return _services.ToArrayOrNull(); }
            set
            {
                if (value == null)
                {
                    _services.Clear();
                }
                else
                {
                    _services.Clear();
                    _services.AddRange(value);
                }
            }
        }

        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        [JsonProperty(PropertyName = "env")]
        public string[] Environment { get; set; }

        [JsonIgnore]
        public Instance[] Instances { get; set; }

        [JsonIgnore]
        public VcapUser User { get; set; }

        [JsonIgnore]
        public bool IsStarted
        {
            get { return State == VcapStates.Started; }
        }

        [JsonIgnore]
        public bool IsStopped
        {
            get { return State == VcapStates.Stopped; }
        }

        [JsonIgnore]
        public bool CanStart
        {
            get { return ! (State == VcapStates.Running || State == VcapStates.Started || State == VcapStates.Starting); }
        }

        [JsonIgnore]
        public bool CanStop
        {
            get { return State == VcapStates.Running || State == VcapStates.Started || State == VcapStates.Starting; }
        }

        public void Start()
        {
            State = VcapStates.Started;
        }

        public void Stop()
        {
            State = VcapStates.Stopped;
        }

        public void AddService(string provisionedServiceName)
        {
            _services.Add(provisionedServiceName);
        }

        #region Nested type: VcapStates

        private static class VcapStates
        {
            public const string Starting = "Starting";
            public const string Stopped = "STOPPED";
            public const string Running = "RUNNING";
            public const string Started = "STARTED";
        }

        #endregion
    }

    [Serializable]
    public class Staging : EntityBase
    {
        private string model;
        private string stack;

        [JsonProperty(PropertyName = "model")]
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        [JsonProperty(PropertyName = "stack")]
        public string Stack
        {
            get { return stack; }
            set { stack = value; }
        }
    }

    [Serializable]
    public class AppResources : EntityBase
    {
        private int disk;
        private int fds;
        private int memory;

        [JsonProperty(PropertyName = "memory")]
        public int Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        [JsonProperty(PropertyName = "disk")]
        public int Disk
        {
            get { return disk; }
            set { disk = value; }
        }

        [JsonProperty(PropertyName = "fds")]
        public int Fds
        {
            get { return fds; }
            set { fds = value; }
        }
    }
}