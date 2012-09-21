// -----------------------------------------------------------------------
// <copyright file="Application.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [Serializable]
    public class Application : EntityBase
    {
        private static class VcapStates
        {
            public const string Starting = "Starting";
            public const string Stopped  = "STOPPED";
            public const string Running  = "RUNNING";
            public const string Started  = "STARTED";
        }

        private string name;
        private Staging staging;
        private string version;
        private int instances;
        private int? runningInstances;
        private AppResources resources;
        private string state;
        private List<string> services = new List<string>();

        public Application()
        {
            Staging = new Staging();
            Resources = new AppResources();
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [JsonProperty(PropertyName = "staging")]
        public Staging Staging
        {
            get { return this.staging; }
            set { this.staging = value; }
        }

        [JsonProperty(PropertyName = "uris")]
        public string[] Uris { get; set; }

        [JsonProperty(PropertyName = "instances")]
        public int InstanceCount
        {
            get { return this.instances; }
            set { this.instances = value; }
        }

        [JsonProperty(PropertyName = "runningInstances")]
        public int? RunningInstances
        {
            get { return this.runningInstances; }
            set { this.runningInstances = value; }
        }

        [JsonProperty(PropertyName = "resources")]
        public AppResources Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        [JsonProperty(PropertyName = "state")]
        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        [JsonProperty(PropertyName = "services")]
        public string[] Services
        {
            get
            {
                return services.ToArrayOrNull();
            }
            set
            {
                if (value == null)
                {
                    services.Clear();
                }
                else
                {
                    services.Clear();
                    services.AddRange(value);
                }
            }
        }

        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get { return this.version; }
            set { this.version = value; }
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
            get
            {
                return ! (State == VcapStates.Running || State == VcapStates.Started || State == VcapStates.Starting);
            }
        }

        [JsonIgnore]
        public bool CanStop
        {
            get
            {
                return State == VcapStates.Running || State == VcapStates.Started || State == VcapStates.Starting;
            }
        }

        public void Start()
        {
            this.State = VcapStates.Started;
        }

        public void Stop()
        {
            this.State = VcapStates.Stopped;
        }

        public void AddService(string provisionedServiceName)
        {
            services.Add(provisionedServiceName);
        }
    }

    [Serializable]
    public class Staging : EntityBase
    {
        private string model;
        private string stack;

        [JsonProperty(PropertyName = "model")]
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        [JsonProperty(PropertyName = "stack")]
        public string Stack
        {
            get { return this.stack; }
            set { this.stack = value; }
        }
    }

    [Serializable]
    public class AppResources : EntityBase
    {
        private int memory;
        private int disk;
        private int fds;

        [JsonProperty(PropertyName = "memory")]
        public int Memory
        {
            get { return this.memory; }
            set { this.memory = value; }
        }

        [JsonProperty(PropertyName = "disk")]
        public int Disk
        {
            get { return this.disk; }
            set { this.disk = value; }
        }

        [JsonProperty(PropertyName = "fds")]
        public int Fds
        {
            get { return this.fds; }
            set { this.fds = value; }
        }
    }   
}
