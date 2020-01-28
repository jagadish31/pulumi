// Copyright 2016-2019, Pulumi Corporation

using System;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Pulumi
{
    /// <summary>
    /// Base type for all resource argument classes.
    /// </summary>
    public abstract class ResourceArgs : InputArgs, IResourceArgs
    {
        public static readonly ResourceArgs Empty = new EmptyResourceArgs();

        protected ResourceArgs()
        {
        }

        Task<ImmutableDictionary<string, object?>> IResourceArgs.ToDictionaryAsync()
            => base.ToDictionaryAsync();

        private protected override void ValidateMember(Type memberType, string fullName)
        {
            if (!typeof(IInput).IsAssignableFrom(memberType))
            {
                throw new InvalidOperationException($"{fullName} must be an Input<T>");
            }
        }

        private class EmptyResourceArgs : ResourceArgs
        {
        }
    }
    
    internal interface IResourceArgs
    {
        Task<ImmutableDictionary<string, object?>> ToDictionaryAsync();
    }
}
