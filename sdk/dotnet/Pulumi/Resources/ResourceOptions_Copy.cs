﻿// Copyright 2016-2019, Pulumi Corporation

using System.Collections.Generic;
using System.Linq;

namespace Pulumi
{
    public partial class ResourceOptions
    {
        internal static TResourceOptions CreateCopy<TResourceOptions>(ResourceOptions options) where TResourceOptions : ResourceOptions, new()
            => new TResourceOptions
            {
                Aliases = options.Aliases.ToList(),
                CustomTimeouts = CustomTimeouts.Clone(options.CustomTimeouts),
                DependsOn = options.DependsOn.Clone(),
                Id = options.Id,
                Parent = options.Parent,
                IgnoreChanges = options.IgnoreChanges.ToList(),
                Protect = options.Protect,
                Provider = options.Provider,
                ResourceTransformations = options.ResourceTransformations.ToList(),
                Version = options.Version
            };

        internal static ResourceOptions CreateResourceOptionsCopy(ResourceOptions options)
            => CreateCopy<ResourceOptions>(options);

        internal static CustomResourceOptions CreateCustomResourceOptionsCopy(ResourceOptions? options)
        {
            var copy = CreateCopy<CustomResourceOptions>(options ?? new ResourceOptions());

            var customOptions = options as CustomResourceOptions;
            copy.AdditionalSecretOutputs = customOptions?.AdditionalSecretOutputs.ToList() ?? new List<string>();
            copy.DeleteBeforeReplace = customOptions?.DeleteBeforeReplace;
            copy.ImportId = customOptions?.ImportId;

            return copy;
        }

        internal static ComponentResourceOptions CreateComponentResourceOptionsCopy(ResourceOptions? options)
        {
            var copy = CreateCopy<ComponentResourceOptions>(options ?? new ResourceOptions());

            var componentOptions = options as ComponentResourceOptions;
            copy.Providers = componentOptions?.Providers.ToList() ?? new List<ProviderResource>();

            return copy;
        }
    }
}
