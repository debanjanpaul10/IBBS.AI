// *********************************************************************************
//	<copyright file="KernelFactory.cs" company="Personal">
//		Copyright (c) 2025 Personal
//	</copyright>
// <summary>Kernel factory.</summary>
// *********************************************************************************

namespace IBBS.AI.API.Configuration
{
    using IBBS.AI.Core.Plugins;
    using IBBS.AI.Shared.Constants;
    using Microsoft.SemanticKernel;
    using Microsoft.SemanticKernel.Memory;
    using static IBBS.AI.Shared.Constants.ConfigurationConstants;

    /// <summary>
    /// Kernel factory.
    /// </summary>
    public static class KernelFactory
    {
#pragma warning disable SKEXP0001 
#pragma warning disable SKEXP0050 
        /// <summary>
        /// Creates memory.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public static Func<IServiceProvider, ISemanticTextMemory> CreateMemory()
        {
            return provider =>
            {
                var memoryBuilder = new MemoryBuilder();
                memoryBuilder.WithMemoryStore(new VolatileMemoryStore());

                return memoryBuilder.Build();
            };
        }

        /// <summary>
        /// Creates kernel.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public static Func<IServiceProvider, Kernel> CreateKernel(IConfiguration configuration)
        {
            return provider =>
            {
                var modelId = configuration[GeminiAiModelIdConstant];
                var apiKey = configuration[GeminiAPIKeyConstant];
                var kernelBuilder = Kernel.CreateBuilder();

                if (!string.IsNullOrEmpty(modelId) && !string.IsNullOrEmpty(apiKey))
                {
#pragma warning disable SKEXP0070

                    kernelBuilder.AddGoogleAIGeminiChatCompletion(modelId, apiKey);
                    kernelBuilder.AddGoogleAIEmbeddingGeneration(modelId, apiKey);

                    kernelBuilder.Services.AddSingleton(CreateMemory());
                }
                var kernel = kernelBuilder.Build();

                // Import Plugins
                kernel.Plugins.AddFromType<RewriteTextPlugin>(PromptsConstants.RewritePlugins);

                return kernel;
            };
        }
    }

}

