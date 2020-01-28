// Copyright 2016-2020, Pulumi Corporation

using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Pulumi
{
    public class DictionaryResource : Resource
    {
#pragma warning disable RS0022 // Constructor make noninheritable base class inheritable
        public DictionaryResource(string type, string name, ImmutableDictionary<string, object?> args, ResourceOptions? options = null)
            : base(type, name, true, new DictionaryResourceArgs(args), options ?? new ResourceOptions())
#pragma warning restore RS0022 // Constructor make noninheritable base class inheritable
        {
        }
        
        private class DictionaryResourceArgs : IResourceArgs
        {
            private readonly ImmutableDictionary<string, object?> _dict;
            
            internal DictionaryResourceArgs(ImmutableDictionary<string, object?> dict)
            {
                _dict = dict;
            }

            Task<ImmutableDictionary<string, object?>> IResourceArgs.ToDictionaryAsync()
                => Task.FromResult(_dict);
        }
    }
}
